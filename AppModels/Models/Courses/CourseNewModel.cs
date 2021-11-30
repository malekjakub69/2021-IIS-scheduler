using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseNewModel
    {
        public int Year { get; set; }
        public string Name { get; set; }
    }
    
    public class CourseNewMapperProfile : Profile
    {
        public CourseNewMapperProfile()
        {
            CreateMap<CourseNewModel, Course>();
        }
    }
}
