using System;
using System.Collections.Generic;
using AppEntities.Entities;
using AppModels.Models.Participants;
using AutoMapper;

namespace AppModels.Models.Leaders
{
    public class LeaderDetailModel
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        
        public List<LeaderDetailVerificationModel> VerificationList { get; set; }
        public List<LeaderDetailCourseLeaderModel> CourseList { get; set; }
        public LeaderDetailUserModel User { get; set; }
        public List<LeaderDetailScheduleDataModel> ScheduleDataList { get; set; }
    }

    public class LeaderDetailMapperProfile : Profile
    {
        public LeaderDetailMapperProfile()
        {
            CreateMap<Leader, LeaderDetailModel>();
        }
    }
}