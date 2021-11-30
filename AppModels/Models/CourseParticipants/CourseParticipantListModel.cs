using System;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseParticipants
{
    public class CourseParticipantListModel
    {
        public Guid Id { get; set; }
    }
    
    public class CourseParticipantListMapperProfile : Profile
    {
        public CourseParticipantListMapperProfile()
        {
            CreateMap<CourseParticipant, CourseParticipantListModel>();
        }
    }
}
