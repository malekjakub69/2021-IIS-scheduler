using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseDetailCourseLeaderModel
    {
        public Guid Id { get; set; }
        public CourseDetailLeaderModel Leader { get; set; }
    }
    
    public class CourseDetailCourseLeaderMapperProfile : Profile
    {
        public CourseDetailCourseLeaderMapperProfile()
        {
            CreateMap<CourseLeader, CourseDetailCourseLeaderModel>();
        }
    }
}
