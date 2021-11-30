using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseLeaders
{
    public class CourseLeaderDetailModel
    {
        public Guid Id { get; set; }
        
        public List<CourseLeaderDetailCourseModel> CourseList{ get; set; }
        public List<CourseLeaderDetailLeaderModel> LeaderList { get; set; }
    }

    public class CourseLeaderDetailMapperProfile : Profile
    {
        public CourseLeaderDetailMapperProfile()
        {
            CreateMap<CourseLeader, CourseLeaderDetailModel>();
        }
    }
}