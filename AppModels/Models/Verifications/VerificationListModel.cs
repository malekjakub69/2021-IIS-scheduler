using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Verifications
{
    public class VerificationListModel
    {
        public Guid Id { get; set; }
        //IDK
    }
    public class VerificationListMapperProfile : Profile
    {
        public VerificationListMapperProfile()
        {
            CreateMap<Verification, VerificationListModel>();
        }
    }
}
