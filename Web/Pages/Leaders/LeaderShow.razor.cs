using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Courses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Leaders
{
    public partial class LeaderShow
    {
        //TODO : _courseId je potřeba získat z výběru kurzu. Potřeba změnit na CourseId
        readonly Guid _courseId = new Guid("3AF39CEA-F868-49F6-468F-08D9B1BC37BB");
        [Inject] private HttpClient httpClient { get; set; }
        [Parameter] public Guid CourseId { get; set; }

        private List<CourseDetailCourseLeaderModel> Leaders { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CourseDetailModel Course;
            var response = await httpClient.GetAsync($"course/{_courseId}");
            var content = await response.Content.ReadAsStringAsync();
            Course = JsonConvert.DeserializeObject<CourseDetailModel>(content);
            if (Course != null)
            {
                Leaders = Course.LeaderList;
            }
        }
    }
}