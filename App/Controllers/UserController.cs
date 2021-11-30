using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AppEntities.Entities;
using AppModels.Models.Users;
using App.Facades;
using App.Repositories;
using AppEntities.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;

        private readonly UserFacade userFacade;
        private readonly UserRepository userRepository;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            IConfiguration configuration, UserFacade userFacade, UserRepository userRepository)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.userFacade = userFacade;
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult<List<UserListModel>> GetAll()
        {
            return userFacade.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailModel>> GetById(Guid id)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IdentityUser identityUser = await userManager.FindByEmailAsync(userEmail);
            var roles = await userManager.GetRolesAsync(identityUser);

            UserDetailModel user = userFacade.GetById(id);
            
            if (roles.FirstOrDefault() != "Administrator")
            {
                if (user.Email != userEmail)
                {
                    return Unauthorized();
                }
            }

            return user;
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Guid?>> Update(UserUpdateModel user)
        {
            await UpdateUser(user);
            user.PasswordHash = "Example_pswd123";

            return userFacade.Update(user);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await DeleteUser(id);
            userFacade.Delete(id);
            return Ok();
        }

        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            string username = user.Email;
            string password = user.PasswordHash;

            IdentityUser identityUser = new IdentityUser
            {
                Email = username,
                UserName = username
            };

            IdentityResult identityResult = await userManager.CreateAsync(identityUser, password);
            IdentityResult roleResult = await userManager.AddToRoleAsync(identityUser, "User");

            if (identityResult.Succeeded && roleResult.Succeeded)
            {
                int index = user.Email.IndexOf('@');
                user.Username = username.Substring(0, index);
                user.PasswordHash = "Example_pswd123";
                user.Role = Roles.User;
                userRepository.Create(user);

                return Ok(new { identityResult.Succeeded });
            }
            else
            {
                string errors = "Registrace selhala s následujícími errory";

                foreach (var error in identityResult.Errors)
                {
                    errors += Environment.NewLine;
                    errors += $"Kód chyby : {error.Code} - {error.Description}";
                }

                return StatusCode(StatusCodes.Status500InternalServerError, errors);
            }
        }

        [Route("signin")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] User user)
        {
            string username = user.Email;
            string password = user.PasswordHash;

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(username, password, false, false);

            if (signInResult.Succeeded == true)
            {
                IdentityUser identityUser = await userManager.FindByNameAsync(username);
                string JSONWebTokenAsString = await GenerateJSONToToken(identityUser);
                return Ok(JSONWebTokenAsString);
            }
            else
            {
                return Unauthorized(user);
            }
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<string> GenerateJSONToToken(IdentityUser identityUser)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
            };

            IList<string> roleNames = await userManager.GetRolesAsync(identityUser);
            claims.AddRange(roleNames.Select(roleName => new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                claims,
                null,
                DateTime.UtcNow.AddDays(28),
                credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task UpdateUser(UserUpdateModel user)
        {
            IdentityUser identityUser = await userManager.FindByEmailAsync(user.Email);
            string role = "User";
            string password = user.PasswordHash;

            if (user.Role == Roles.Admin)
                role = "Administrator";
            else if (user.Role == Roles.Leader)
                role = "Leader";

            var token = await userManager.GeneratePasswordResetTokenAsync(identityUser);

            IdentityResult passwordResult = await userManager.ResetPasswordAsync(identityUser, token, user.PasswordHash);

            var identityRoles = await userManager.GetRolesAsync(identityUser);
            IdentityResult roleRemoveResult = await userManager.RemoveFromRoleAsync(identityUser, identityRoles.FirstOrDefault()); 
            IdentityResult roleResult = await userManager.AddToRoleAsync(identityUser, role);
        }

        private async Task DeleteUser(Guid Id)
        {
            User user = userRepository.GetById(Id);
            string role = "User";

            if (user.Role == Roles.Admin)
                role = "Administrator";
            else if (user.Role == Roles.Leader)
                role = "Leader";

            IdentityUser identityUser = await userManager.FindByEmailAsync(user.Email);
            IdentityResult deleteRoleResult = await userManager.RemoveFromRoleAsync(identityUser, role);
            IdentityResult deleteResult = await userManager.DeleteAsync(identityUser);
        }
    }
}
