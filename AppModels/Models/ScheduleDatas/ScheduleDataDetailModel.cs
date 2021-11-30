using System;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDataDetailModel
    {
        
        public Guid Id { get; set; }
        public ScheduleDataDetailCourseModel Course { get; set; }
        public ScheduleDataDetailLeaderModel Leader { get; set; }
        public ScheduleDataDetailCompetenceModel Competence { get; set; }
        public ScheduleDataDetailParticipantModel Participant { get; set; }
        public ScheduleDataDetailTimeBlockModel TimeBlock { get; set; }
    }

    public class ScheduleDataDetailMapperProfile : Profile
    {
        public ScheduleDataDetailMapperProfile()
        {
            CreateMap<ScheduleData, ScheduleDataDetailModel>();
        }
    }
}