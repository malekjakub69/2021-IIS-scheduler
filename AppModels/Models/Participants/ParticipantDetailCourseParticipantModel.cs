using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class ParticipantDetailCourseParticipantModel
    {
        public ParticipantDetailCourseModel Course { get; set; }
    }
    
    public class ParticipantDetailCourseParticipantMapperProfile : Profile
    {
        public ParticipantDetailCourseParticipantMapperProfile()
        {
            CreateMap<CourseParticipant, ParticipantDetailCourseParticipantModel>();
        }
    }
}
