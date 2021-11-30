using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Participants;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseDetailParticipantModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Surname { get; set; }
        
        public List<ParticipantDetailScheduleDataModel> ScheduleData { get; set; }
        public List<CourseDetailCompetenceModel> DoneList { get; set; }
    }
    public class CourseDetailParticipantMapperProfile : Profile
    {
        public CourseDetailParticipantMapperProfile()
        {
            CreateMap<Participant, CourseDetailParticipantModel>();
        }
    }
}
