using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseDetailModel
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public CoursesType Type { get; set; }

        public List<CourseDetailCourseParticipantModel> ParticipantList { get; set; }
        public List<CourseDetailCourseLeaderModel> LeaderList { get; set; }

        public List<CourseDetailScheduleListModel> ScheduleList { get; set; }
    }

    public class CourseDetailMapperProfile : Profile
    {
        public CourseDetailMapperProfile()
        {
            CreateMap<Course, CourseDetailModel>();
        }
    }
}