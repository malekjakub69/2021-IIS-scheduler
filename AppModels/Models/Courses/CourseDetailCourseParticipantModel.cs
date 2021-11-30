using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseDetailCourseParticipantModel
    {
        public Guid Id { get; set; }
        public CourseDetailParticipantModel Participant { get; set; }
    }
    public class CourseDetailCourseParticipantMapperProfile : Profile
    {
        public CourseDetailCourseParticipantMapperProfile()
        {
            CreateMap<CourseParticipant, CourseDetailCourseParticipantModel>();
        }
    }
}
