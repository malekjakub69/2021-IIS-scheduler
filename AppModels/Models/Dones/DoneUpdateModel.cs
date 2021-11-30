using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Dones
{
    public class DoneUpdateModel
    {
        //IDK
    }
    public class DoneUpdateMapperProfile : Profile
    {
        public DoneUpdateMapperProfile()
        {
            CreateMap<DoneUpdateModel, Done>();
        }
    }
}
