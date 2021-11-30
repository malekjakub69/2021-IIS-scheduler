using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseLeaders
{
    public class CourseLeaderNewModel
    {
        public Guid LeaderId { get; set; }
        public Guid CourseId { get; set; }
    }
    
    public class CourseLeaderNewMapperProfile : Profile
    {
        public CourseLeaderNewMapperProfile()
        {
            CreateMap<CourseLeaderNewModel, CourseLeader>();
        }
    }
}
