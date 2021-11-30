using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.Competences;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class CompetenceFacade : IAppFacade
    {
        public readonly CompetenceRepository CompetenceRepository;
        public readonly IMapper Mapper;

        public CompetenceFacade(CompetenceRepository competenceRepository,
            IMapper mapper)
        {
            this.CompetenceRepository = competenceRepository;
            this.Mapper = mapper;
        }

        public List<CompetenceListModel> GetAll()
        {
            return Mapper.Map<List<CompetenceListModel>>(CompetenceRepository.GetAll());
        }

        public CompetenceDetailModel GetById(Guid id)
        {
            return Mapper.Map<CompetenceDetailModel>(CompetenceRepository.GetById(id));
        }

        public Guid Create(CompetenceNewModel competence)
        {
            var competenceEntity = Mapper.Map<Competence>(competence);
            return CompetenceRepository.Create(competenceEntity);
        }

        public Guid? Update(CompetenceUpdateModel competence)
        {
            var competenceEntity = Mapper.Map<Competence>(competence);
            return CompetenceRepository.Update(competenceEntity);
        }

        public void Delete(Guid id)
        {
            CompetenceRepository.Delete(id);
        }

    }
}
