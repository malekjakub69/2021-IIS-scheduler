using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Dones
{
    public class DoneListModel
    {
        public Guid Id { get; set; }
        //IDK
    }
    
    public class DoneListMapperProfile : Profile
    {
        public DoneListMapperProfile()
        {
            CreateMap<Done, DoneListModel>();
        }
    }
    
}
