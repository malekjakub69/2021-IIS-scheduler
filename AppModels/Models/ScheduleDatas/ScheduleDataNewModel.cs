using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.ScheduleDatas
{
    public class ScheduleDataNewModel
    {
        public Guid LeaderId { get; set; }
        public Guid CompetenceId { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid TimeBlockId { get; set; }
    }
    public class ScheduleDataNewMapperProfile : Profile
    {
        public ScheduleDataNewMapperProfile()
        {
            CreateMap<ScheduleDataNewModel, ScheduleData>();
        }
    }
}
