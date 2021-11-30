using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppEntities.Enums;
using AppModels.Models.Courses;
using AppModels.Models.Leaders;
using AppModels.Models.ScheduleDatas;
using AppModels.Models.Schedules;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Web.Pages.Schedule
{
    public partial class ScheduleForm
    {
        [Parameter] public Guid CourseId { get; set; }
        [Inject] private HttpClient httpClient { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private Guid SelectedLeader { get; set; } = Guid.Empty;
        private Guid SelectedParticipant { get; set; } = Guid.Empty;
        private Guid SelectedSchedule { get; set; } = Guid.Empty;
        private Guid SelectedTimeBlock { get; set; } = Guid.Empty;
        private Guid SelectedCompetence { get; set; } = Guid.Empty;

        private CoursesType CourseType { get; set; }
        private List<CourseDetailCourseParticipantModel> Participants { get; set; }
        private List<CourseDetailCourseLeaderModel> Leaders { get; set; }
        private List<CourseDetailScheduleListModel> Schedules { get; set; }
        private List<LeaderDetailVerificationCompetenceModel> Competences { get; set; }
        private List<ScheduleDetailTimeBlockModel> TimeBlocks { get; set; }


        private bool missingValue = false;
        private bool competenceSelected = true;
        private bool timeBlockSelected = true;
        private string error = "";
        protected override async Task OnInitializedAsync()
        {
            CourseDetailModel course;
            var response = await httpClient.GetAsync($"course/{CourseId}");
            var content = await response.Content.ReadAsStringAsync();
            course = JsonConvert.DeserializeObject<CourseDetailModel>(content);

            if (course != null)
            {
                Participants = course.ParticipantList;
                Leaders = course.LeaderList;
                Schedules = course.ScheduleList;
                CourseType = course.Type;
            }
        }
        private async void SelectLeader(ChangeEventArgs e)
        {
            SelectedCompetence = Guid.Empty;
            competenceSelected = true;
            SelectedLeader = new Guid(e.Value.ToString());
            await GetCompetences();
        }
        private async void SelectParticipant(ChangeEventArgs e)
        {
            SelectedCompetence = Guid.Empty;
            competenceSelected = true;
            SelectedParticipant = new Guid(e.Value.ToString());
            await GetCompetences();
        }
        
        private async void SelectTimeBlock(ChangeEventArgs e)
        {
            timeBlockSelected = false;
            SelectedTimeBlock = new Guid(e.Value.ToString());
        }
        
        private async void SelectSchedule(ChangeEventArgs e)
        {
            SelectedTimeBlock = Guid.Empty;
            timeBlockSelected = true;
            SelectedSchedule = new Guid(e.Value.ToString());
            await GetTimeBlocks();
        }
        
        private async void SelectCompetence(ChangeEventArgs e)
        {
            competenceSelected = false;
            SelectedCompetence = new Guid(e.Value.ToString());
        }

        private async Task Save()
        {
            if (SelectedParticipant != Guid.Empty &&
                SelectedLeader != Guid.Empty &&
                SelectedTimeBlock != Guid.Empty &&
                SelectedCompetence != Guid.Empty)
            {
                ScheduleDataNewModel newData = new ScheduleDataNewModel
                {
                    CompetenceId = SelectedCompetence,
                    ParticipantId = SelectedParticipant,
                    LeaderId = SelectedLeader,
                    TimeBlockId = SelectedTimeBlock
                };
                var jsonData = JsonConvert.SerializeObject(newData);
                var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("scheduleData", content);

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Notify succesful creation of new scheduleData
                    NavigationManager.NavigateTo(NavigationManager.Uri, true);
                }
                else
                {
                    error = responseMessage.Content.ToString();
                }
            }
            else
            {
                missingValue = true;
            }

        }


        private async Task GetCompetences()
        {
            if (SelectedParticipant != new Guid() && SelectedLeader != new Guid())
            {
                LeaderDetailModel leader;
                var response = await httpClient.GetAsync($"leader/{SelectedLeader}");
                var content = await response.Content.ReadAsStringAsync();
                leader = JsonConvert.DeserializeObject<LeaderDetailModel>(content);
                Competences = new List<LeaderDetailVerificationCompetenceModel>();

                if (leader != null)
                    foreach (var verification in leader.VerificationList)
                    {
                        if (verification.Competence.Type == CourseType)
                            Competences.Add(verification.Competence);
                    }
                StateHasChanged();
            }
        }
        private async Task GetTimeBlocks()
        {
            if (SelectedSchedule != new Guid())
            {
                ScheduleDetailModel schedule;
                var response = await httpClient.GetAsync($"schedule/{SelectedSchedule}");
                var content = await response.Content.ReadAsStringAsync();
                schedule = JsonConvert.DeserializeObject<ScheduleDetailModel>(content);

                if (schedule != null)
                    TimeBlocks = schedule.TimeBlockList;
            }
            StateHasChanged();
        }
        private int Redirect(string uri)
        {
            //UriHelper.NavigateTo(uri);
            return 0;
        }
    }
}