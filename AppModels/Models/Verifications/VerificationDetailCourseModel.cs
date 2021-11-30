﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using AutoMapper;

namespace AppModels.Models.Verifications
{
    public class VerificationDetailCourseModel
    {
        public int Year { get; set; }
        public string Name { get; set; }
    }
    public class VerificationDetailCourseMapperProfile : Profile
    {
        public VerificationDetailCourseMapperProfile()
        {
            CreateMap<Course, VerificationDetailCourseModel>();
        }
    }
}
