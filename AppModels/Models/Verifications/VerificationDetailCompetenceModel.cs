using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Verifications
{
    public class VerificationDetailCompetenceModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public CoursesType Type { get; set; }
    }
    public class VerificationDetailCompetenceMapperProfile : Profile
    {
        public VerificationDetailCompetenceMapperProfile()
        {
            CreateMap<Competence, VerificationDetailCompetenceModel>();
        }
    }
}
