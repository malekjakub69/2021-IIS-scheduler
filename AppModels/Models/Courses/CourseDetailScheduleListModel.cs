using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseDetailScheduleListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<CourseDetailScheduleTimeBlockListModel> TimeBlockList { get; set; }

    }
    public class CourseDetailScheduleMapperProfile : Profile
    {
        public CourseDetailScheduleMapperProfile()
        {
            CreateMap<Schedule, CourseDetailScheduleListModel>();
        }
    }
}