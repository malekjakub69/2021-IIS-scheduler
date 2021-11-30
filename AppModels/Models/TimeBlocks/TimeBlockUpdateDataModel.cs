using System;
using AppEntities.Entities;
using AppModels.Models.ScheduleDatas;
using AutoMapper;

namespace AppModels.Models.Schedules
{
    public class TimeBlockUpdateDataModel
    {
        public Guid Id { get; set; }
    }
    
    public class TimeBlockUpdateDataMapperProfile : Profile
    {
        public TimeBlockUpdateDataMapperProfile()
        {
            CreateMap<TimeBlockUpdateDataModel, ScheduleData>();
        }
    }
}