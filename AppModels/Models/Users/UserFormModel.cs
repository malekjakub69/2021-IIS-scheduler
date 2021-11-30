using System;
using System.Collections.Generic;
using System.Text;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Users
{
    public class UserFormModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
    
}
