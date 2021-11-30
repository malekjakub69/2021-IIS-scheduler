using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Schedules
{
    public class ScheduleDetailModel
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        
        public List<ScheduleDetailTimeBlockModel> TimeBlockList { get; set; }
    }

    public class ScheduleDetailMapperProfile : Profile
    {
        public ScheduleDetailMapperProfile()
        {
            CreateMap<Schedule, ScheduleDetailModel>();
        }
    }
}