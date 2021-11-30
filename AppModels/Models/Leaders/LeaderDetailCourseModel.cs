using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Leaders
{
    public class LeaderDetailCourseModel
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
    }
    
    public class LeaderDetailCourseMapperProfile : Profile
    {
        public LeaderDetailCourseMapperProfile()
        {
            CreateMap<Course, LeaderDetailCourseModel>();
        }
    }
}
