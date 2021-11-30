using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Schedules
{
    public class ScheduleDetailTimeBlockModel
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public List<ScheduleDetailDataModel> ScheduleDataList { get; set; }
    }
    
    public class ScheduleDetailTimeBlockMapperProfile : Profile
    {
        public ScheduleDetailTimeBlockMapperProfile()
        {
            CreateMap<TimeBlock, ScheduleDetailTimeBlockModel>();
        }
    }
}
