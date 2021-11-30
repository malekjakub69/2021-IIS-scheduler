using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppModels.Models.Courses;
using AppModels.Models.Schedules;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Schedule
{
    public partial class ScheduleTimeBlock
    {
        [Parameter] public ScheduleDetailTimeBlockModel TimeBlock { get; set; }
        [Parameter]  public List<CourseDetailCourseLeaderModel> Leaders { get; set; }
    }
}