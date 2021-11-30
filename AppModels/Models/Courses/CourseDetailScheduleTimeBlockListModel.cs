using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseDetailScheduleTimeBlockListModel
    {
        public Guid Id { get; set; }

    }
    public class CourseDetailScheduleTimeBlockListMapperProfile : Profile
    {
        public CourseDetailScheduleTimeBlockListMapperProfile()
        {
            CreateMap<TimeBlock, CourseDetailScheduleTimeBlockListModel>();
        }
    }
}