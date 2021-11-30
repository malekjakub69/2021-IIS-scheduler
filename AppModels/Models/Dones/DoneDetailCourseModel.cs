using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Dones
{
    public class DoneDetailCourseModel
    {
        public int Year { get; set; }
        public string Name { get; set; }
        
    }
    public class DoneDetailCourseMapperProfile : Profile
    {
        public DoneDetailCourseMapperProfile()
        {
            CreateMap<Course, DoneDetailCourseModel>();
        }
    }
}
