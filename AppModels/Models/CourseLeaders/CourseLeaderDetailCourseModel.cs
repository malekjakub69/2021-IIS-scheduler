using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseLeaders
{
    public class CourseLeaderDetailCourseModel
    {
        public Guid Id { get; set; }        
        public int Year { get; set; }
        public string Name { get; set; }
    }
    public class CourseLeaderDetailParticipantMapperProfile : Profile
    {
        public CourseLeaderDetailParticipantMapperProfile()
        {
            CreateMap<Participant, CourseLeaderDetailCourseModel>();
        }
    }
}
