using System;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Verifications
{
    public class VerificationDetailModel
    {
        public Guid Id { get; set; }
        public VerificationDetailCompetenceModel Competence { get; set; }
        public VerificationDetailLeaderModel Leader { get; set; }
        public VerificationDetailCourseModel Course { get; set; }
    }

    public class VerificationDetailMapperProfile : Profile
    {
        public VerificationDetailMapperProfile()
        {
            CreateMap<Verification, VerificationDetailModel>();
        }
    }
}