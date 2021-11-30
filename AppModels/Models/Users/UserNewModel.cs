using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Users
{
    public class UserNewModel
    {        
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Roles Role { get; set; }
    }
    public class UserNewMapperProfile : Profile
    {
        public UserNewMapperProfile()
        {
            CreateMap<UserNewModel, User>();
        }
    }
}
