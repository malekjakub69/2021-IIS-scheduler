using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Courses;
using AppModels.Models.Schedules;
using AppModels.Models.TimeBlocks;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Schedule
{
    public partial class TimeBlockNewItem
    {
        [Parameter] public Guid ScheduleId { get; set; }
        [Inject] private HttpClient httpClient { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        private TimeBlockNewModel TimeBlock { get; set; } = new TimeBlockNewModel();
        public string DateTimeFrom { get; set; }
        public string DateTimeTo { get; set; }
        public async Task Create()
        {
            TimeBlock.ScheduleId = ScheduleId;
            TimeBlock.To = DateTime.Parse(DateTimeTo);
            TimeBlock.From = DateTime.Parse(DateTimeFrom);
            var jsonData = JsonConvert.SerializeObject(TimeBlock);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("timeblock", content);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NavigationManager.NavigateTo(NavigationManager.Uri, true);
            }
        }
    }
}