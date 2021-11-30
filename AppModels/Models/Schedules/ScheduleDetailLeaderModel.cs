using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDetailLeaderModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
    }
    
    public class ScheduleDetailLeaderMapperProfile : Profile
    {
        public ScheduleDetailLeaderMapperProfile()
        {
            CreateMap<Leader, ScheduleDetailLeaderModel>();
        }
    }
}
