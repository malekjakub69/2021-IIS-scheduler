using System;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseParticipants
{
    public class CourseParticipantUpdateModel
    {
        public Guid Id { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid CourseId { get; set; }
    }

    public class CourseParticipantUpdateMapperProfile : Profile
    {
        public CourseParticipantUpdateMapperProfile()
        {
            CreateMap<CourseParticipantUpdateModel, CourseParticipant>();
        }
    }
}
