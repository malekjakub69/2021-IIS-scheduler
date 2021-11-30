using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseUpdateModel
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
    }

    public class CourseUpdateMapperProfile : Profile
    {
        public CourseUpdateMapperProfile()
        {
            CreateMap<CourseUpdateModel, Course>();
        }
    }
}
