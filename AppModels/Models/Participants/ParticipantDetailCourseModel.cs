using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class ParticipantDetailCourseModel
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
    }
    
    public class ParticipantDetailCourseMapperProfile : Profile
    {
        public ParticipantDetailCourseMapperProfile()
        {
            CreateMap<Course, ParticipantDetailCourseModel>();
        }
    }
}
