using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.TimeBlocks
{
    public class TimeBlockListModel
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    public class TimeBlockListMapperProfile : Profile
    {
        public TimeBlockListMapperProfile()
        {
            CreateMap<TimeBlock, TimeBlockListModel>();
        }
    }
}
