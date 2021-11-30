using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.Schedules;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class ScheduleFacade : IAppFacade
    {
        public readonly ScheduleRepository ScheduleRepository;
        public readonly IMapper Mapper;

        public ScheduleFacade(ScheduleRepository scheduleRepository,
            IMapper mapper)
        {
            this.ScheduleRepository = scheduleRepository;
            this.Mapper = mapper;
        }

        public List<ScheduleListModel> GetAll()
        {
            return Mapper.Map<List<ScheduleListModel>>(ScheduleRepository.GetAll());
        }

        public ScheduleDetailModel GetById(Guid id)
        {
            return Mapper.Map<ScheduleDetailModel>(ScheduleRepository.GetById(id));
        }

        public Guid Create(ScheduleNewModel schedule)
        {
            var scheduleEntity = Mapper.Map<Schedule>(schedule);
            return ScheduleRepository.Create(scheduleEntity);
        }

        public Guid? Update(ScheduleUpdateModel schedule)
        {
            var scheduleEntity = Mapper.Map<Schedule>(schedule);
            return ScheduleRepository.Update(scheduleEntity);
        }

        public void Delete(Guid id)
        {
            ScheduleRepository.Delete(id);
        }

    }
}
