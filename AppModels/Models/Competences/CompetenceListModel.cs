using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Competences
{
    public class CompetenceListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }

    public class CompetenceListMapperProfile : Profile
    {
        public CompetenceListMapperProfile()
        {
            CreateMap<Competence, CompetenceListModel>();
        }
    }
}
