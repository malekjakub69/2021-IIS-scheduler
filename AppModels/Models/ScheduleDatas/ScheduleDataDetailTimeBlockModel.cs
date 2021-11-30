using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDataDetailTimeBlockModel
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }    public class ScheduleDataDetailTimeBlockMapperProfile : Profile
    {
        public ScheduleDataDetailTimeBlockMapperProfile()
        {
            CreateMap<TimeBlock, ScheduleDataDetailTimeBlockModel>();
        }
    }
}
