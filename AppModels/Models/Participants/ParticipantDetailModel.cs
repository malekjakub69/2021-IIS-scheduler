using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class ParticipantDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        
        public List<ParticipantDetailDoneModel> DoneList { get; set; }
        public List<ParticipantDetailCourseParticipantModel> CourseList { get; set; }
        public ParticipantDetailUserModel User { get; set; }
        public List<ParticipantDetailScheduleDataModel> ScheduleData { get; set; }
    }

    public class ParticipantDetailMapperProfile : Profile
    {
        public ParticipantDetailMapperProfile()
        {
            CreateMap<Participant, ParticipantDetailModel>();
        }
    }
}