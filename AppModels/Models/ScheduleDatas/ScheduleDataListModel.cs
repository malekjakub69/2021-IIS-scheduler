using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDataListModel
    {
        public Guid Id { get; set; }
        public ScheduleDataDetailCourseModel Course { get; set; }
        public ScheduleDataDetailLeaderModel Leader { get; set; }
        public ScheduleDataDetailCompetenceModel Competence { get; set; }
        public ScheduleDataDetailParticipantModel Participant { get; set; }
        public ScheduleDataDetailTimeBlockModel TimeBlock { get; set; }
    }
    public class ScheduleDataListMapperProfile : Profile
    {
        public ScheduleDataListMapperProfile()
        {
            CreateMap<ScheduleData, ScheduleDataListModel>();
        }
    }
}
