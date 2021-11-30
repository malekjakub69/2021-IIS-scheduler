using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class ParticipantNewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
    }
    
    public class ParticipantNewMapperProfile : Profile
    {
        public ParticipantNewMapperProfile()
        {
            CreateMap<ParticipantNewModel, Participant>();
        }
    }
}
