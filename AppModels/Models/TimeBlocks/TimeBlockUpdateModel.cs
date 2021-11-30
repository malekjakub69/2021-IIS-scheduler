using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Schedules;
using AutoMapper;

namespace AppModels.Models.TimeBlocks
{
    public class TimeBlockUpdateModel
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid ScheduleId { get; set; }
        public List<TimeBlockUpdateDataModel> ScheduleDataList { get; set; }
    }
    public class TimeBlockUpdateMapperProfile : Profile
    {
        public TimeBlockUpdateMapperProfile()
        {
            CreateMap<TimeBlockUpdateModel, TimeBlock>();
        }
    }
}
