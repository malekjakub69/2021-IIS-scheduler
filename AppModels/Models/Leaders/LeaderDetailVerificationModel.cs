using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Leaders
{
    public class LeaderDetailVerificationModel
    {
        public LeaderDetailVerificationCompetenceModel Competence { get; set; }
    } 
    
    public class LeaderDetailVerificationMapperProfile : Profile
    {
        public LeaderDetailVerificationMapperProfile()
        {
            CreateMap<Verification, LeaderDetailVerificationModel>();
        }
    }
}
