using System;
using System.Collections.Generic;
using AppModels.Models.Courses;
using Microsoft.AspNetCore.Components;

namespace Web.Pages.Schedule
{
    public partial class ScheduleEditComponent
    {
        [Parameter] public List<CourseDetailScheduleListModel> Schedules { get; set; }
        [Parameter] public Guid CourseId { get; set; }
        
    }
}