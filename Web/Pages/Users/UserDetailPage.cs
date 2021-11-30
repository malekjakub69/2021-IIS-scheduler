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
    public partial class UserDetailPage
    {
        [Parameter] public Guid UserId { get; set; }

        [Inject] private HttpClient httpClient { get; set; }

        private UserDetailModel User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"user/{UserId}");
            var content = await response.Content.ReadAsStringAsync();
            User = JsonConvert.DeserializeObject<UserDetailModel>(content);

            await base.OnInitializedAsync();
        }

        private string MapUserRole(Roles role)
        {
            if (role == Roles.Admin)
                return "Administrator";
            else if (role == Roles.Leader)
                return "Vedoucí";

            return "Bežný uživatel";
        }
    }
}
