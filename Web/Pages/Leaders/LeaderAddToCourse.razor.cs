using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.CourseLeaders;
using AppModels.Models.CourseLeaders;
using AppModels.Models.Courses;
using AppModels.Models.Leaders;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Leaders
{
    public partial class LeaderAddToCourse
    {
        
        
        readonly Guid _courseId = new Guid("3AF39CEA-F868-49F6-468F-08D9B1BC37BB");

        [Inject] private HttpClient httpClient { get; set; }
        [Parameter] public Guid CourseId { get; set; }

        private List<LeaderDetailModel> LeadersInCourse { get; set; }
        private List<LeaderDetailModel> LeaderInSystem { get; set; }

        private CourseDetailModel Course;
        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"course/{_courseId}");
            var content = await response.Content.ReadAsStringAsync();

            Course = JsonConvert.DeserializeObject<CourseDetailModel>(content);
            LeadersInCourse = new List<LeaderDetailModel>();

            if (Course != null)
            {
                foreach (var leader in Course.LeaderList)
                {
                    LeadersInCourse.Add(new LeaderDetailModel
                    {
                        Id = leader.Leader.Id,
                        Name = leader.Leader.Name,
                        Surname = leader.Leader.Surname,
                        Nickname = leader.Leader.Nickname,
                        ScheduleDataList = leader.Leader.ScheduleData
                    });
                }
            }

            response = await httpClient.GetAsync($"leader");
            content = await response.Content.ReadAsStringAsync();
            List<LeaderDetailModel> leaders = JsonConvert.DeserializeObject<List<LeaderDetailModel>>(content);

            LeaderInSystem = new List<LeaderDetailModel>();

            foreach (var leadersInSystem in leaders)
            {
                if (!LeadersInCourse.Exists(item => item.Id == leadersInSystem.Id))
                {
                    LeaderInSystem.Add(leadersInSystem);
                }
            }
        }

        private async Task ToCourse(Guid leaderId)
        {
            
            CourseLeaderNewModel newContent = new CourseLeaderNewModel
            {
                CourseId = CourseId,
                LeaderId = leaderId
            };
            var jsonData = JsonConvert.SerializeObject(newContent);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"courseLeader", content);
            StateHasChanged();
        }
        
        private async Task FromCourse(Guid leaderId)
        {

            Guid relationsId = Course.LeaderList.Find(a => a.Leader.Id == leaderId).Id;
            var response = await httpClient.DeleteAsync($"courseLeader/{relationsId}");
            StateHasChanged();
        }
    }
}