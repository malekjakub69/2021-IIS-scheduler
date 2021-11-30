using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using AppEntities.Entities;
using AppModels.Models.Users;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using AppEntities.Enums;

namespace Web.Pages.Users
{
    public partial class UserEditPage
    {
        [Parameter] public Guid UserId { get; set; }

        [Inject] private HttpClient httpClient { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        public bool Edited { get; set; } = false;

        public bool Error { get; set; } = false;

        private UserUpdateModel User { get; set; }

        public Roles Role { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"user/{UserId}");
            var content = await response.Content.ReadAsStringAsync();
            User = JsonConvert.DeserializeObject<UserUpdateModel>(content);

            await base.OnInitializedAsync();
        }

        public async Task Update()
        {
            User.Id = UserId;
            User.Role = Role;

            var jsonData = JsonConvert.SerializeObject(User);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("user", content);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Edited = true;
            }
            else
            {
                Error = true;
            }
            NavigationManager.NavigateTo("/user");
        }

        public async Task Delete()
        {
            await httpClient.DeleteAsync($"user/{UserId}");
            NavigationManager.NavigateTo($"/user");
        }
    }
}
