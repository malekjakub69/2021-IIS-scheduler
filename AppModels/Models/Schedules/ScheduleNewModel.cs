using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Schedules
{
    public class ScheduleNewModel
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
    }
    public class ScheduleNewMapperProfile : Profile
    {
        public ScheduleNewMapperProfile()
        {
            CreateMap<ScheduleNewModel, Schedule>();
        }
    }
}
