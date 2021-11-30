using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AppEntities.Entities;
using AppEntities.Enums;
using AutoMapper;

namespace AppModels.Models.Competences
{
    public class CompetenceDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public CoursesType Type { get; set; }
    }

    public class CompetenceDetailMapperProfile : Profile
    {
        public CompetenceDetailMapperProfile()
        {
            CreateMap<Competence, CompetenceDetailModel>();
        }
    }
}