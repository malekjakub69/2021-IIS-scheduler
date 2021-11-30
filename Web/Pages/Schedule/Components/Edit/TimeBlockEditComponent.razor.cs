using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppModels.Models.Courses;
using Microsoft.AspNetCore.Components;

namespace Web.Pages.Schedule
{
    public partial class TimeBlockEditComponent
    {
        [Parameter] public List<CourseDetailScheduleListModel> Schedules { get; set; }

        private Guid SelectedId { get; set; }

        private void SelectId(ChangeEventArgs e)
        {
            SelectedId = new Guid(e.Value.ToString());
            StateHasChanged();
        }
    }
}