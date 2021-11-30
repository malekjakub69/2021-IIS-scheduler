using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Courses;
using AppModels.Models.Schedules;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Web.Pages.Schedule
{
    public partial class ScheduleShowData
    {
        [Parameter] public List<ScheduleDetailTimeBlockModel> Data { get; set; }
        [Parameter] public List<CourseDetailCourseLeaderModel> Leaders { get; set; }
    }
}