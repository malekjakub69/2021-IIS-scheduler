using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Schedules;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Schedule
{
    public partial class ScheduleItem
    {
        [Parameter] public ScheduleDetailDataModel Item { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private HttpClient httpClient { get; set; }

        private string Color { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Color = Item.Participant.Color ?? "";
        }

        private async Task Remove()
        {
            await httpClient.DeleteAsync($"scheduleData/{Item.Id}");
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }
    }
}