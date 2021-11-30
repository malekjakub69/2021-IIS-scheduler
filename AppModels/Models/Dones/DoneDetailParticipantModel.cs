using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Dones
{
    public class DoneDetailParticipantModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
    }
    public class DoneDetailParticipantMapperProfile : Profile
    {
        public DoneDetailParticipantMapperProfile()
        {
            CreateMap<Participant, DoneDetailParticipantModel>();
        }
    }
}
