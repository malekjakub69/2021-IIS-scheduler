using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.CourseLeaders
{
    public class CourseLeaderDetailLeaderModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Surname { get; set; }
    }
    public class CourseLeaderLeaderDetailLeaderMapperProfile : Profile
    {
        public CourseLeaderLeaderDetailLeaderMapperProfile()
        {
            CreateMap<Leader, CourseLeaderDetailLeaderModel>();
        }
    }
}
