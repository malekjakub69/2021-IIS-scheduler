using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseLeaders
{
    public class CourseLeaderUpdateModel
    {
        public Guid Id { get; set; }
        public Guid LeaderId { get; set; }
        public Guid CourseId { get; set; }
    }

    public class CourseLeaderUpdateMapperProfile : Profile
    {
        public CourseLeaderUpdateMapperProfile()
        {
            CreateMap<CourseLeaderUpdateModel, CourseLeader>();
        }
    }
}
