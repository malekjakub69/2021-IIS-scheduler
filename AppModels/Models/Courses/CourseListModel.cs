using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Competences;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseListModel
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
    }
    
    public class CourseListMapperProfile : Profile
    {
        public CourseListMapperProfile()
        {
            CreateMap<Course, CourseListModel>();
        }
    }
}
