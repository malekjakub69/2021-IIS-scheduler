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
    public partial class TimeBlockEditItem
    {
        [Parameter] public Guid TimeBlockId { get; set; }
        [Inject] private HttpClient httpClient { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        public string DateTimeFrom { get; set; }
        public string DateTimeTo { get; set; }

        private string test = "";
        private TimeBlockUpdateModel TimeBlock { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"timeblock/{TimeBlockId}");
            var content = await response.Content.ReadAsStringAsync();
            TimeBlock = JsonConvert.DeserializeObject<TimeBlockUpdateModel>(content);
            if (TimeBlock != null)
            {
                DateTimeFrom = TimeBlock.From.ToString();
                DateTimeTo = TimeBlock.To.ToString();
            }
        }
        
        public async Task Update()
        {
            TimeBlock.To = DateTime.Parse(DateTimeTo);
            TimeBlock.From = DateTime.Parse(DateTimeFrom);
            
            var jsonData = JsonConvert.SerializeObject(TimeBlock);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("timeBlock", content);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NavigationManager.NavigateTo(NavigationManager.Uri, true);
            }
        }
        
        public async Task Remove()
        {
            foreach (var data in TimeBlock.ScheduleDataList)
            {
                await httpClient.DeleteAsync($"scheduleData/{data.Id}");
            }
            await httpClient.DeleteAsync($"timeBlock/{TimeBlock.Id}");
            NavigationManager.NavigateTo(NavigationManager.Uri, true);

        }
    }
}