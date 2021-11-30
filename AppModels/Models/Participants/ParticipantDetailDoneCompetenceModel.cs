using System;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Leaders
{
    public class ParticipantDetailDoneCompetenceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public CoursesType Type { get; set; }
    }
    
    public class ParticipantDetailDoneCompetenceMapperProfile : Profile
    {
        public ParticipantDetailDoneCompetenceMapperProfile()
        {
            CreateMap<Competence, ParticipantDetailDoneCompetenceModel>();
        }
    }
}