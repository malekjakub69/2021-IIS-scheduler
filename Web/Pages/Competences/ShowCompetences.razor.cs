using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Competences;
using AppModels.Models.Courses;
using AppModels.Models.Participants;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Competences
{
    public partial class ShowCompetences
    {
        [Inject] private HttpClient httpClient { get; set; }

        [Parameter] public Guid CourseId { get; set; }

        private ParticipantDetailModel Participant { get; set; }
        
        private List<CompetenceListModel> Competences { get; set; }

        private Guid ParticipantId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            string uuid = "92337280-AAC4-42A2-DA4B-08D9B1BC7E36";
            var response = await httpClient.GetAsync($"participant/{uuid}");
            var content = await response.Content.ReadAsStringAsync();
            Participant = JsonConvert.DeserializeObject<ParticipantDetailModel>(content);
            
            response = await httpClient.GetAsync($"competence");
            content = await response.Content.ReadAsStringAsync();
            Competences = JsonConvert.DeserializeObject<List<CompetenceListModel>>(content);
        }
    }
}