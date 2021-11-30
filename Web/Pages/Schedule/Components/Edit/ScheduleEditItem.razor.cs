using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Courses;
using AppModels.Models.Schedules;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Schedule
{
    public partial class ScheduleEditItem
    {
        [Parameter] public Guid ScheduleId { get; set; }
        [Inject] private HttpClient httpClient { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        

        private ScheduleDetailModel Schedule { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"schedule/{ScheduleId}");
            var content = await response.Content.ReadAsStringAsync();
            Schedule = JsonConvert.DeserializeObject<ScheduleDetailModel>(content);

        }
        
        public async Task Update()
        {
            ScheduleUpdateModel update = new ScheduleUpdateModel
            {
                Id = Schedule.Id,
                Name = Schedule.Name,
                CourseId = Schedule.CourseId
            };
            
            var jsonData = JsonConvert.SerializeObject(update);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("schedule", content);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NavigationManager.NavigateTo(NavigationManager.Uri, true);
            }
        }
        
        public async Task Remove()
        {
            await httpClient.DeleteAsync($"schedule/{Schedule.Id}");
            NavigationManager.NavigateTo(NavigationManager.Uri, true);

        }
    }
}