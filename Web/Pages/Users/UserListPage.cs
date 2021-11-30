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
    public partial class UserListPage
    { 
        [Inject] private HttpClient httpClient { get; set; }

        private List<UserListModel> Users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"user");
            var content = await response.Content.ReadAsStringAsync();
            Users = JsonConvert.DeserializeObject<List<UserListModel>>(content);

            await base.OnInitializedAsync();
        }
    }
}
