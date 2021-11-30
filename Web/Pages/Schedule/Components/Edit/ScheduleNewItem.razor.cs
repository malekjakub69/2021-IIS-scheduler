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
    public partial class ScheduleNewItem
    {
        [Parameter] public Guid CourseId { get; set; }
        [Inject] private HttpClient httpClient { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        private ScheduleNewModel Schedule { get; set; } = new ScheduleNewModel();
        
        public async Task Create()
        {
            Schedule.CourseId = CourseId;
            var jsonData = JsonConvert.SerializeObject(Schedule);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("schedule", content);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NavigationManager.NavigateTo(NavigationManager.Uri, true);
            }
        }
    }
}