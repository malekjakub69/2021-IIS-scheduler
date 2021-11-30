using System;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Leaders
{
    public class LeaderDetailVerificationCompetenceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public CoursesType Type { get; set; }
    }
    
    public class LeaderDetailVerificationCompetenceMapperProfile : Profile
    {
        public LeaderDetailVerificationCompetenceMapperProfile()
        {
            CreateMap<Competence, LeaderDetailVerificationCompetenceModel>();
        }
    }
}