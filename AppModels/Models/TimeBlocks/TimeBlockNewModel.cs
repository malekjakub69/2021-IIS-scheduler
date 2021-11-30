using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.TimeBlocks
{
    public class TimeBlockNewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid ScheduleId { get; set; }
    }
    
    public class TimeBlockNewMapperProfile : Profile
    {
        public TimeBlockNewMapperProfile()
        {
            CreateMap<TimeBlockNewModel, TimeBlock>();
        }
    }
}
