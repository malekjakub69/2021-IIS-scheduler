using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.Dones;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class DoneFacade : IAppFacade
    {
        public readonly DoneRepository DoneRepository;
        public readonly IMapper Mapper;

        public DoneFacade(DoneRepository doneRepository,
            IMapper mapper)
        {
            this.DoneRepository = doneRepository;
            this.Mapper = mapper;
        }

        public List<DoneListModel> GetAll()
        {
            return Mapper.Map<List<DoneListModel>>(DoneRepository.GetAll());
        }

        public DoneDetailModel GetById(Guid id)
        {
            return Mapper.Map<DoneDetailModel>(DoneRepository.GetById(id));
        }

        public Guid Create(DoneNewModel done)
        {
            var doneEntity = Mapper.Map<Done>(done);
            return DoneRepository.Create(doneEntity);
        }

        public Guid? Update(DoneUpdateModel done)
        {
            var doneEntity = Mapper.Map<Done>(done);
            return DoneRepository.Update(doneEntity);
        }

        public void Delete(Guid id)
        {
            DoneRepository.Delete(id);
        }

    }
}
