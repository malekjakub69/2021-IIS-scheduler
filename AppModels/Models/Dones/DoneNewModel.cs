using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Dones
{
    public class DoneNewModel
    {
        //IDK
    }
    public class DoneNewMapperProfile : Profile
    {
        public DoneNewMapperProfile()
        {
            CreateMap<DoneNewModel, Done>();
        }
    }
}
