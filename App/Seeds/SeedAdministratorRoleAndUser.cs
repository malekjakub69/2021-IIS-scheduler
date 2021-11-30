using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace App.Seeds
{
    public static class SeedAdministratorRoleAndUser
    {

        internal async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            await SeedAdministratorRole(roleManager);
            await SeedLeaderRole(roleManager);
            await SeedUserRole(roleManager);
            await SeedAdministratorUser(userManager);
        }

        private async static Task SeedAdministratorRole(RoleManager<IdentityRole> roleManager)
        {
            bool administratorRoleExists = await roleManager.RoleExistsAsync("Administrator");

            if (!administratorRoleExists)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };

                await roleManager.CreateAsync(role);
            }
        }

        private async static Task SeedLeaderRole(RoleManager<IdentityRole> roleManager)
        {
            bool leaderRoleExists = await roleManager.RoleExistsAsync("Leader");

            if (!leaderRoleExists)
            {
                var role = new IdentityRole
                {
                    Name = "Leader"
                };

                await roleManager.CreateAsync(role);
            }
        }

        private async static Task SeedUserRole(RoleManager<IdentityRole> roleManager)
        {
            bool userRoleExists = await roleManager.RoleExistsAsync("User");

            if (!userRoleExists)
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };

                await roleManager.CreateAsync(role);
            }
        }

        private async static Task SeedAdministratorUser(UserManager<IdentityUser> userManager)
        {
            bool administratorUserExists = await userManager.FindByEmailAsync("admin@example.com") != null;
            

            if (!administratorUserExists)
            {
                var administratorUser = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                IdentityResult identityResult = await userManager.CreateAsync(administratorUser, "!!!Admin123");
                IdentityResult roleResult = await userManager.AddToRoleAsync(administratorUser, "Administrator");
            }
        }
    }
}
