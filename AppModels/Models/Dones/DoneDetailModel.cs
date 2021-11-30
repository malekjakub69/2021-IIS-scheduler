using System;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Dones
{
    public class DoneDetailModel
    {
        
        public Guid Id { get; set; }
        public DoneDetailCompetenceModel Competence { get; set; }
        public DoneDetailParticipantModel Participant { get; set; }
        public DoneDetailCourseModel Course { get; set; }
    }

    public class DoneDetailMapperProfile : Profile
    {
        public DoneDetailMapperProfile()
        {
            CreateMap<Done, DoneDetailModel>();
        }
    }
}