using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDataDetailCourseModel
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
    }    public class ScheduleDataDetailCourseMapperProfile : Profile
    {
        public ScheduleDataDetailCourseMapperProfile()
        {
            CreateMap<Course, ScheduleDataDetailCourseModel>();
        }
    }
}
