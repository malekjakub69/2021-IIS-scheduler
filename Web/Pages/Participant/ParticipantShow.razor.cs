using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Courses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Participant
{
    public partial class ParticipantShow
    {
        [Inject] private HttpClient httpClient { get; set; }
        [Parameter] public Guid CourseId { get; set; }

        private List<CourseDetailCourseParticipantModel> Participants { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CourseDetailModel Course;
            var response = await httpClient.GetAsync($"course/{CourseId}");
            var content = await response.Content.ReadAsStringAsync();
            Course = JsonConvert.DeserializeObject<CourseDetailModel>(content);
            if (Course != null)
            {
                Participants = Course.ParticipantList;
            }
        }
    }
}