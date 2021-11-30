using System;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseParticipants
{
    public class CourseParticipantDetailParticipantModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Surname { get; set; }
    }
    public class CourseParticipantDetailParticipantMapperProfile : Profile
    {
        public CourseParticipantDetailParticipantMapperProfile()
        {
            CreateMap<Participant, CourseParticipantDetailParticipantModel>();
        }
    }
}
