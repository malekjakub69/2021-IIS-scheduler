using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AppModels.Models.Participants;
using AutoMapper;

namespace AppModels.Models.Courses
{
    public class CourseDetailCompetenceModel
    {
        public Guid Id { get; set; }
    }
    public class CourseDetailDoneListeMapperProfile : Profile
    {
        public CourseDetailDoneListeMapperProfile()
        {
            CreateMap<Done, CourseDetailCompetenceModel>();
        }
    }
}
