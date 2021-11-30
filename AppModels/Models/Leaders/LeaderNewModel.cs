using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Leaders
{
    public class LeaderNewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
    }
    
    public class LeaderNewMapperProfile : Profile
    {
        public LeaderNewMapperProfile()
        {
            CreateMap<LeaderNewModel, Leader>();
        }
    }
}
