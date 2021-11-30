using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AppModels.Models.Schedules;
using AutoMapper;

namespace AppModels.Models.TimeBlocks
{
    public class TimeBlockDetailModel
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public List<TimeBlockDataModel> ScheduleDataList { get; set; }
    }

    public class TimeBlockDetailMapperProfile : Profile
    {
        public TimeBlockDetailMapperProfile()
        {
            CreateMap<TimeBlock, TimeBlockDetailModel>();
        }
    }
}