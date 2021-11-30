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
    
    public partial class ScheduleEdit
    {
        [Inject] private HttpClient httpClient { get; set; }
        [Parameter] public Guid CourseId { get; set; }

        private List<CourseDetailScheduleListModel> Schedules { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CourseDetailModel Course;
            var response = await httpClient.GetAsync($"course/{CourseId}");
            var content = await response.Content.ReadAsStringAsync();
            Course = JsonConvert.DeserializeObject<CourseDetailModel>(content);

            if (Course != null) Schedules = Course.ScheduleList;
        }
    }
}