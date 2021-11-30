using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Users
{
    public class UserDetailParticipantModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
    }
    public class UserDetailParticipantMapperProfile : Profile
    {
        public UserDetailParticipantMapperProfile()
        {
            CreateMap<Participant, UserDetailParticipantModel>();
        }
    }
    
}
