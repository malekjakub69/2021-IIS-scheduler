using System;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseParticipants
{
    public class CourseParticipantNewModel
    {
        public Guid ParticipantId { get; set; }
        public Guid CourseId { get; set; }
    }
    
    public class CourseParticipantNewMapperProfile : Profile
    {
        public CourseParticipantNewMapperProfile()
        {
            CreateMap<CourseParticipantNewModel, CourseParticipant>();
        }
    }
}
