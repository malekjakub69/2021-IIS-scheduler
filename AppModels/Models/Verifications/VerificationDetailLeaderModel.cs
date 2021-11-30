using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Verifications
{
    public class VerificationDetailLeaderModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
    }
    
    public class VerificationDetailLeaderMapperProfile : Profile
    {
        public VerificationDetailLeaderMapperProfile()
        {
            CreateMap<Leader, VerificationDetailLeaderModel>();
        }
    }
}
