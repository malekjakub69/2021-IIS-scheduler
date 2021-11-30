using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Leaders
{
    public class LeaderDetailUserModel
    {
        public string Username { get; set; }        
        public string Email { get; set; }
        public Roles Role { get; set; }
    }
    
    public class LeaderDetailUserMapperProfile : Profile
    {
        public LeaderDetailUserMapperProfile()
        {
            CreateMap<User, LeaderDetailUserModel>();
        }
    }
}
