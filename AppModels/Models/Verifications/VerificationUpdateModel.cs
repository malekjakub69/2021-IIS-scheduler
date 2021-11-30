using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Verifications
{
    public class VerificationUpdateModel
    {
    }
    public class VerificationUpdateMapperProfile : Profile
    {
        public VerificationUpdateMapperProfile()
        {
            CreateMap<VerificationUpdateModel, Verification >();
        }
    }
}
