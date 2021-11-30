using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Courses;
using AppModels.Models.Schedules;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Web.Pages.Schedule;

namespace Web.Pages.Schedule
{
    public partial class ShowSchedule
    {
        [Parameter] public Guid CourseId { get; set; }
        [Parameter] public Guid ScheduleId { get; set; }
        [Inject] private HttpClient httpClient { get; set; }

        private List<ScheduleListModel> Schedules { get; set; }

        protected override async Task OnInitializedAsync()
        {
            List<ScheduleListModel> SchedulesTmp;
            var response = await httpClient.GetAsync($"schedule");
            var content = await response.Content.ReadAsStringAsync();
            SchedulesTmp = JsonConvert.DeserializeObject<List<ScheduleListModel>>(content);

            Schedules = new List<ScheduleListModel>();
            if (SchedulesTmp != null)
            {
                foreach (var schedule in SchedulesTmp)
                {
                    if (schedule.CourseId == CourseId)
                    {
                        Schedules.Add(schedule);
                    }
                }
            }
        }
        
        private async void SelectSchedule(ChangeEventArgs e)
        {
            ScheduleId = new Guid(e.Value.ToString());
            StateHasChanged();
        }
    }
}