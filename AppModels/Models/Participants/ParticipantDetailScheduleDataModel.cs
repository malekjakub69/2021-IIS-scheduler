using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class ParticipantDetailScheduleDataModel
    {
        public Guid Id { get; set; }
    }
    
    public class ParticipantDetailScheduleDataMapperProfile : Profile
    {
        public ParticipantDetailScheduleDataMapperProfile()
        {
            CreateMap<ScheduleData, ParticipantDetailScheduleDataModel>();
        }
    }
}
