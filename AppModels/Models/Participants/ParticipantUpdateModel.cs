using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class ParticipantUpdateModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
    }
    
    public class ParticipantUpdateMapperProfile : Profile
    {
        public ParticipantUpdateMapperProfile()
        {
            CreateMap<ParticipantUpdateModel, Participant>();
        }
    }
}
