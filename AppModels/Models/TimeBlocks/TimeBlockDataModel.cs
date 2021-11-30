using System;
using AppEntities.Entities;
using AppModels.Models.ScheduleDatas;
using AutoMapper;

namespace AppModels.Models.Schedules
{
    public class TimeBlockDataModel
    {
        public Guid Id { get; set; }
    }
    
    public class TimeBlockDataMapperProfile : Profile
    {
        public TimeBlockDataMapperProfile()
        {
            CreateMap<ScheduleData, TimeBlockDataModel>();
        }
    }
}