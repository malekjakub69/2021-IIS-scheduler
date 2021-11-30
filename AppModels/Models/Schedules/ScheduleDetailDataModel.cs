using System;
using AppEntities.Entities;
using AppModels.Models.ScheduleDatas;
using AutoMapper;

namespace AppModels.Models.Schedules
{
    public class ScheduleDetailDataModel
    {
        public Guid Id { get; set; }
        public ScheduleDetailLeaderModel Leader { get; set; }
        public ScheduleDetailCompetenceModel Competence { get; set; }
        public ScheduleDetailParticipantModel Participant { get; set; }
    }
    
    public class ScheduleDetailDataMapperProfile : Profile
    {
        public ScheduleDetailDataMapperProfile()
        {
            CreateMap<ScheduleData, ScheduleDetailDataModel>();
        }
    }
}