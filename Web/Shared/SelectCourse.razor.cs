using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Courses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Web.Shared
{
    public partial class SelectCourse
    {
        [Inject]
        private HttpClient httpClient { get; set; }

        [Inject] NavigationManager NavigationManager { get; set; }

        public string SelectedId { get; set; } = null;

        public string ShowScheduleHref { get; set; }

        public string AddScheduleHref { get; set; }

        public string EditScheduleHref { get; set; }
        public string ShowLeaderHref { get; set; }
        public string ShowCompetenceHref { get; set; }
        public string ShowParticipantHref { get; set; }
        public string AddToCourseLeaderHref { get; set; }
        public string AddToCourseParticipantHref { get; set; }

        private List<CourseListModel> Courses { get; set; }

        private bool CourseUpdate { get; set; } = true;


        protected override async Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync($"course");
            var content = await response.Content.ReadAsStringAsync();
            Courses = JsonConvert.DeserializeObject<List<CourseListModel>>(content);
            Console.WriteLine(CourseUpdate);
            Console.WriteLine(NavigationManager.BaseUri);
            string url = NavigationManager.Uri;
            if (url.Contains("course/"))
            {
                Regex r = new Regex("(course\\/)([^\\/]+)(\\/)", RegexOptions.IgnoreCase);
                Match match = r.Match(url);

                SelectedId = match.Groups[2].Value;
                CourseUpdate = true;
            }
            else
            {
                CourseUpdate = false;
                SelectedId = "3AF39CEA-F868-49F6-468F-08D9B1BC37BB";
            }

            Console.WriteLine(CourseUpdate);
            ShowScheduleHref = "/course/" + SelectedId + "/schedule";
            AddScheduleHref = ShowScheduleHref + "/add";
            EditScheduleHref = ShowScheduleHref + "/edit";

            ShowCompetenceHref= "/course/" + SelectedId + "/competence/show";
            ShowLeaderHref = "/course/" + SelectedId + "/leader/show";
            ShowParticipantHref = "/course/" + SelectedId + "/participant/show";
            AddToCourseLeaderHref = "/course/" + SelectedId + "/leader/add";
            AddToCourseParticipantHref = "/course/" + SelectedId + "/participant/add";
            StateHasChanged();
        }       

        private void UpdateNav(ChangeEventArgs e)
        {
            string newId = e.Value.ToString();
            Console.WriteLine(CourseUpdate);
            if (CourseUpdate)
            {
                string url = NavigationManager.Uri;
                string newUrl = url.Replace(SelectedId, newId);
                Console.WriteLine(newUrl);
                NavigationManager.NavigateTo(newUrl, true);
            }
            else
            {
                Console.WriteLine(CourseUpdate);
                ShowScheduleHref = ShowScheduleHref.Replace(SelectedId, newId);
                AddScheduleHref = AddScheduleHref.Replace(SelectedId, newId);
                EditScheduleHref = EditScheduleHref.Replace(SelectedId, newId);
                ShowScheduleHref = ShowScheduleHref.Replace(SelectedId, newId);
                AddScheduleHref = AddScheduleHref.Replace(SelectedId, newId);
                EditScheduleHref = EditScheduleHref.Replace(SelectedId, newId);
                ShowLeaderHref = EditScheduleHref.Replace(SelectedId, newId);
                ShowParticipantHref = EditScheduleHref.Replace(SelectedId, newId);
                AddToCourseLeaderHref = EditScheduleHref.Replace(SelectedId, newId);
                AddToCourseParticipantHref = EditScheduleHref.Replace(SelectedId, newId);
                ShowCompetenceHref = ShowCompetenceHref.Replace(SelectedId, newId);
                SelectedId = newId;
            }
        }
    }
}