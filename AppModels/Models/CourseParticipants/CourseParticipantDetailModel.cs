using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseParticipants
{
    public class CourseParticipantDetailModel
    {
        public Guid Id { get; set; }
        
        public List<CourseParticipantDetailParticipantModel> ParticipantList { get; set; }
        public List<CourseParticipantDetailCourseModel> LeaderList { get; set; }
    }

    public class CourseParticipantDetailMapperProfile : Profile
    {
        public CourseParticipantDetailMapperProfile()
        {
            CreateMap<CourseParticipant, CourseParticipantDetailModel>();
        }
    }
}