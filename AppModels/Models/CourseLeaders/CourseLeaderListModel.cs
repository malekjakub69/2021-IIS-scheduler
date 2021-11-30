using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Competences;
using AutoMapper;

namespace AppModels.Models.CourseLeaders
{
    public class CourseLeaderListModel
    {
        public Guid Id { get; set; }
    }
    
    public class CourseLeaderListMapperProfile : Profile
    {
        public CourseLeaderListMapperProfile()
        {
            CreateMap<CourseLeader, CourseLeaderListModel>();
        }
    }
}
