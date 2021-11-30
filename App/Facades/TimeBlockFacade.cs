using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.TimeBlocks;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class TimeBlockFacade : IAppFacade
    {
        public readonly TimeBlockRepository TimeBlockRepository;
        public readonly IMapper Mapper;

        public TimeBlockFacade(TimeBlockRepository timeBlockRepository,
            IMapper mapper)
        {
            this.TimeBlockRepository = timeBlockRepository;
            this.Mapper = mapper;
        }

        public List<TimeBlockListModel> GetAll()
        {
            return Mapper.Map<List<TimeBlockListModel>>(TimeBlockRepository.GetAll());
        }

        public TimeBlockDetailModel GetById(Guid id)
        {
            return Mapper.Map<TimeBlockDetailModel>(TimeBlockRepository.GetById(id));
        }

        public Guid Create(TimeBlockNewModel timeBlock)
        {
            var timeBlockEntity = Mapper.Map<TimeBlock>(timeBlock);
            return TimeBlockRepository.Create(timeBlockEntity);
        }

        public Guid? Update(TimeBlockUpdateModel timeBlock)
        {
            var timeBlockEntity = Mapper.Map<TimeBlock>(timeBlock);
            return TimeBlockRepository.Update(timeBlockEntity);
        }

        public void Delete(Guid id)
        {
            TimeBlockRepository.Delete(id);
        }

    }
}
