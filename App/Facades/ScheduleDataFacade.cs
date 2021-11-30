using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.ScheduleDatas;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class ScheduleDataFacade : IAppFacade
    {
        public readonly ScheduleDataRepository ScheduleDataRepository;
        public readonly IMapper Mapper;

        public ScheduleDataFacade(ScheduleDataRepository scheduleDataRepository,
            IMapper mapper)
        {
            this.ScheduleDataRepository = scheduleDataRepository;
            this.Mapper = mapper;
        }

        public List<ScheduleDataListModel> GetAll()
        {
            return Mapper.Map<List<ScheduleDataListModel>>(ScheduleDataRepository.GetAll());
        }

        public ScheduleDataDetailModel GetById(Guid id)
        {
            return Mapper.Map<ScheduleDataDetailModel>(ScheduleDataRepository.GetById(id));
        }

        public Guid Create(ScheduleDataNewModel scheduleData)
        {
            var scheduleDataEntity = Mapper.Map<ScheduleData>(scheduleData);
            return ScheduleDataRepository.Create(scheduleDataEntity);
        }

        public Guid? Update(ScheduleDataUpdateModel scheduleData)
        {
            var scheduleDataEntity = Mapper.Map<ScheduleData>(scheduleData);
            return ScheduleDataRepository.Update(scheduleDataEntity);
        }

        public void Delete(Guid id)
        {
            ScheduleDataRepository.Delete(id);
        }

    }
}
