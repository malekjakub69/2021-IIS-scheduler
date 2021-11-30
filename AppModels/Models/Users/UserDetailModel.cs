using System;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Users
{
    public class UserDetailModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Roles Role { get; set; }
        
        public UserDetailParticipantModel Participant { get; set; }
        public UserDetailLeaderModel Leader { get; set; }
    }

    public class UserDetailMapperProfile : Profile
    {
        public UserDetailMapperProfile()
        {
            CreateMap<User, UserDetailModel>();
        }
    }
}