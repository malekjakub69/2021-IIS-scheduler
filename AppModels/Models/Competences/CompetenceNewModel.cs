using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Competences
{
    public class CompetenceNewModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public CoursesType Type { get; set; }
    }
    
    public class CompetenceNewMapperProfile : Profile
    {
        public CompetenceNewMapperProfile()
        {
            CreateMap<CompetenceNewModel, Competence>();
        }
    }
}
