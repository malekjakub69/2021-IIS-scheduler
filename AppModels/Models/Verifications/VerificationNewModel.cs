using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Verifications
{
    public class VerificationNewModel
    {
        public Guid CompetenceId { get; set; }
        public Guid LeaderId { get; set; }
        public Guid CourseId { get; set; }
    }
    public class VerificationNewMapperProfile : Profile
    {
        public VerificationNewMapperProfile()
        {
            CreateMap<VerificationNewModel, Verification >();
        }
    }
}
