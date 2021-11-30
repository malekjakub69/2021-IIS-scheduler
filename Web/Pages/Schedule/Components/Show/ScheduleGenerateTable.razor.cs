using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Courses;
using AppModels.Models.Leaders;
using AppModels.Models.Schedules;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Schedule
{
    public partial class ScheduleGenerateTable
    {
        [Parameter] public Guid CourseId { get; set; }
        [Parameter] public Guid ScheduleId { get; set; }

        [Inject] private HttpClient httpClient { get; set; }

        private List<CourseDetailCourseLeaderModel> Leaders { get; set; }

        public List<ScheduleDetailTimeBlockModel> TimeBlockData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ScheduleDetailModel Schedule;
            var response = await httpClient.GetAsync($"schedule/{ScheduleId}");
            var content = await response.Content.ReadAsStringAsync();
            Schedule = JsonConvert.DeserializeObject<ScheduleDetailModel>(content);

            if (Schedule != null)
            {
                TimeBlockData = Schedule.TimeBlockList;
            }

            CourseDetailModel Courses;
            response = await httpClient.GetAsync($"course/{CourseId}");
            content = await response.Content.ReadAsStringAsync();
            Courses = JsonConvert.DeserializeObject<CourseDetailModel>(content);
            Leaders = new List<CourseDetailCourseLeaderModel>();
            if (Courses != null)
            {
                foreach (var leader in Courses.LeaderList)
                {
                    foreach (var timeBlockdata in TimeBlockData)
                    {
                        ScheduleDetailDataModel tmpLeader =
                            timeBlockdata.ScheduleDataList.Find(a => a.Leader.Id == leader.Leader.Id);
                        if (tmpLeader != null)
                        {
                            Leaders.Add(leader);
                            break;
                        }
                    }
                }
            }
        }
    }
}