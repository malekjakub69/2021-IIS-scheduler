using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.ScheduleDatas;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Leaders
{
    public partial class LeadersSchedules
    {
        [Parameter] public Guid LeaderId { get; set; }
        [Parameter]  public Guid CourseId { get; set; }
        [Inject] private HttpClient httpClient { get; set; }

        private List<ScheduleDataListModel> ScheduleData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CourseId = new Guid("D4A064D3-BEF0-4DD9-9674-F9D512CA1B30");
            LeaderId = new Guid("D4A064D3-BEF0-4DD9-9674-F9D512CA1B30");

            List<ScheduleDataListModel> ScheduleDataTmp;

            var response = await httpClient.GetAsync($"scheduleData");
            var content = await response.Content.ReadAsStringAsync();
            ScheduleDataTmp = JsonConvert.DeserializeObject<List<ScheduleDataListModel>>(content);

            ScheduleData = new List<ScheduleDataListModel>();
            if (ScheduleDataTmp != null)
            {
                foreach (var data in ScheduleDataTmp)
                {
                }
            }
        }
    }
}