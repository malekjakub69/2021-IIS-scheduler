using System;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseParticipants
{
    public class CourseParticipantDetailCourseModel
    {
        public Guid Id { get; set; }        
        public int Year { get; set; }
        public string Name { get; set; }
    }
    public class CourseParticipantDetailLeaderMapperProfile : Profile
    {
        public CourseParticipantDetailLeaderMapperProfile()
        {
            CreateMap<Leader, CourseParticipantDetailCourseModel>();
        }
    }
}
