using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Users
{
    public class UserUpdateModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Roles Role { get; set; }
    }
    public class UserUpdateMapperProfile : Profile
    {
        public UserUpdateMapperProfile()
        {
            CreateMap<UserUpdateModel, User>();
        }
    }
}
