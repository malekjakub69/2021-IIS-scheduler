using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDataDetailCompetenceModel
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public CoursesType Type { get; set; }
    }    public class ScheduleDataDetailCompetenceMapperProfile : Profile
    {
        public ScheduleDataDetailCompetenceMapperProfile()
        {
            CreateMap<Competence, ScheduleDataDetailCompetenceModel>();
        }
    }
}
