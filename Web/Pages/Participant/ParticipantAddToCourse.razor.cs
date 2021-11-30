using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.CourseParticipants;
using AppModels.Models.Courses;
using AppModels.Models.Participants;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Participant
{
    public partial class ParticipantAddToCourse
    {
        
        readonly Guid _courseId = new Guid("3AF39CEA-F868-49F6-468F-08D9B1BC37BB");

        [Inject] private HttpClient httpClient { get; set; }
        [Parameter] public Guid CourseId { get; set; }

        private List<ParticipantDetailModel> ParticipantsInCourse { get; set; }
        private List<ParticipantDetailModel> ParticipantInSystem { get; set; }

        private CourseDetailModel Course;
        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"course/{_courseId}");
            var content = await response.Content.ReadAsStringAsync();

            Course = JsonConvert.DeserializeObject<CourseDetailModel>(content);
            ParticipantsInCourse = new List<ParticipantDetailModel>();

            if (Course != null)
            {
                foreach (var participant in Course.ParticipantList)
                {
                    ParticipantsInCourse.Add(new ParticipantDetailModel
                    {
                        Id = participant.Participant.Id,
                        Name = participant.Participant.Name,
                        Surname = participant.Participant.Surname,
                        Nickname = participant.Participant.Nickname,
                        ScheduleData = participant.Participant.ScheduleData
                    });
                }
            }

            response = await httpClient.GetAsync($"participant");
            content = await response.Content.ReadAsStringAsync();
            List<ParticipantDetailModel> participants = JsonConvert.DeserializeObject<List<ParticipantDetailModel>>(content);

            ParticipantInSystem = new List<ParticipantDetailModel>();

            foreach (var participantsInSystem in participants)
            {
                if (!ParticipantsInCourse.Exists(item => item.Id == participantsInSystem.Id))
                {
                    ParticipantInSystem.Add(participantsInSystem);
                }
            }
        }

        private async Task ToCourse(Guid participantId)
        {
            
            CourseParticipantNewModel newContent = new CourseParticipantNewModel
            {
                CourseId = CourseId,
                ParticipantId = participantId
            };
            var jsonData = JsonConvert.SerializeObject(newContent);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"courseParticipant", content);
            StateHasChanged();
        }
        
        private async Task FromCourse(Guid participantId)
        {

            Guid relationsId = Course.ParticipantList.Find(a => a.Participant.Id == participantId).Id;
            var response = await httpClient.DeleteAsync($"courseParticipant/{relationsId}");
            StateHasChanged();
        }
    }
}