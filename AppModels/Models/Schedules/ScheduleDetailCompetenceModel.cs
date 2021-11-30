using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDetailCompetenceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }    
    
    public class ScheduleDetailCompetenceMapperProfile : Profile
    {
        public ScheduleDetailCompetenceMapperProfile()
        {
            CreateMap<Competence, ScheduleDetailCompetenceModel>();
        }
    }
}
