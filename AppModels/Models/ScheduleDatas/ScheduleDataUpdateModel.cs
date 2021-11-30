using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDataUpdateModel
    {
        //IDK
    }
    
    public class ScheduleDataUpdateMapperProfile : Profile
    {
        public ScheduleDataUpdateMapperProfile()
        {
            CreateMap<ScheduleDataUpdateModel, ScheduleData>();
        }
    }
}
