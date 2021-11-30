using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Leaders;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class ParticipantDetailDoneModel
    {
        public ParticipantDetailDoneCompetenceModel Competence { get; set; }
    }
    
    public class ParticipantDetailDoneMapperProfile : Profile
    {
        public ParticipantDetailDoneMapperProfile()
        {
            CreateMap<Done, ParticipantDetailDoneModel>();
        }
    }
    
}
