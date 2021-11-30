using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.Leaders;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class LeaderFacade : IAppFacade
    {
        public readonly LeaderRepository LeaderRepository;
        public readonly IMapper Mapper;

        public LeaderFacade(LeaderRepository leaderRepository,
            IMapper mapper)
        {
            this.LeaderRepository = leaderRepository;
            this.Mapper = mapper;
        }

        public List<LeaderListModel> GetAll()
        {
            return Mapper.Map<List<LeaderListModel>>(LeaderRepository.GetAll());
        }

        public LeaderDetailModel GetById(Guid id)
        {
            return Mapper.Map<LeaderDetailModel>(LeaderRepository.GetById(id));
        }

        public Guid Create(LeaderNewModel leader)
        {
            var leaderEntity = Mapper.Map<Leader>(leader);
            return LeaderRepository.Create(leaderEntity);
        }

        public Guid? Update(LeaderUpdateModel leader)
        {
            var leaderEntity = Mapper.Map<Leader>(leader);
            return LeaderRepository.Update(leaderEntity);
        }

        public void Delete(Guid id)
        {
            LeaderRepository.Delete(id);
        }

    }
}
