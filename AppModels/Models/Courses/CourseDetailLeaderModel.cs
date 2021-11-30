using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Participants;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseDetailLeaderModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Surname { get; set; }
        
        public List<LeaderDetailScheduleDataModel> ScheduleData { get; set; }
    }
    public class CourseDetailLeaderMapperProfile : Profile
    {
        public CourseDetailLeaderMapperProfile()
        {
            CreateMap<Leader, CourseDetailLeaderModel>();
        }
    }
}
