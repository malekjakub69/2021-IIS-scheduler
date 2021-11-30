using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class LeaderDetailScheduleDataModel
    {
        public Guid Id { get; set; }
    }

    public class LeaderDetailScheduleDataMapperProfile : Profile
    {
        public LeaderDetailScheduleDataMapperProfile()
        {
            CreateMap<ScheduleData, LeaderDetailScheduleDataModel>();
        }
    }
}