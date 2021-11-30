using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Participants
{
    public class ParticipantDetailUserModel
    {
        public string Username { get; set; }        
        public string Email { get; set; }
        public Roles Role { get; set; }
    }
    
    public class ParticipantDetailUserMapperProfile : Profile
    {
        public ParticipantDetailUserMapperProfile()
        {
            CreateMap<User, ParticipantDetailUserModel>();
        }
    }
}
