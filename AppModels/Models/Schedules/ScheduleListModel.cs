using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Schedules
{
    public class ScheduleListModel
    {
        public Guid Id { get; set; }
        
        public Guid CourseId { get; set; }
        public string Name { get; set; }
    }
    
    public class ScheduleListMapperProfile : Profile
    {
        public ScheduleListMapperProfile()
        {
            CreateMap<Schedule, ScheduleListModel>();
        }
    }
}
