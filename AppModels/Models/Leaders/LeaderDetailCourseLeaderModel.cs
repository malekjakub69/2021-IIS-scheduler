using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Courses;
using AutoMapper;

namespace AppModels.Models.Leaders
{
    public class LeaderDetailCourseLeaderModel
    {
        public CourseDetailLeaderModel Leader { get; set; }
    }
    
    public class LeaderDetailCourseLeaderMapperProfile : Profile
    {
        public LeaderDetailCourseLeaderMapperProfile()
        {
            CreateMap<CourseLeader, LeaderDetailCourseLeaderModel>();
        }
    }
}
