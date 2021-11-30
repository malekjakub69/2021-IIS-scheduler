using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Courses;
using AppModels.Models.Participants;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Web.Shared;

namespace Web.Pages.Competences
{
    public partial class EditCompetences
    {
        [Parameter] public Guid CourseId { get; set; }
        [Inject]private HttpClient httpClient { get; set; }

        public CourseDetailModel Course { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"course/{CourseId}");
            var content = await response.Content.ReadAsStringAsync();
            Course = JsonConvert.DeserializeObject<CourseDetailModel>(content);
        }
    }
}