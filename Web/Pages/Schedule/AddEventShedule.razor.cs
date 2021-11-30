using System;
using Microsoft.AspNetCore.Components;

namespace Web.Pages.Schedule
{
    public partial class AddEventShedule
    {
        [Parameter] public Guid CourseId { get; set; }
    }
}