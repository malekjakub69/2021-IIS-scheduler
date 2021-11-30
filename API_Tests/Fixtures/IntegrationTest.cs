using AppEntities.Entities;
using AppEntities.Enums;
using App.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Xunit;

namespace API_Tests.Fixtures
{
    public class IntegrationTest : IClassFixture<AppFactory>
    {
        protected readonly AppFactory _factory;
        protected readonly HttpClient _client;
        protected readonly IConfiguration _configuration;

        public IntegrationTest(AppFactory fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();
            _configuration = new ConfigurationBuilder()
                  .Build();
        }

        public DbContextOptions<AppDbContext> SetupDbContextOptions()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            context.Competences.Add(
                   new Competence
                   {
                       Name = "Competence Test",
                       Id = new Guid("15949177-2e41-4e1d-8b6f-7d50ac8190cf"),
                       Desc = "Competence Test Description",
                       DoneList = new List<Done>(),
                       ScheduleDataList = new List<ScheduleData>(),
                       Type = CoursesType.LeadershipCourse
                   }
               );
            context.Courses.Add(
                new Course
                {
                    Name = "Course Test",
                    Id = new Guid("9c2c0773-2ea1-4c11-9f86-f93b129e07fc"),
                    ScheduleList = new List<Schedule>(),
                    DoneList = new List<Done>(),
                    LeaderList = new List<CourseLeader>(),
                    ParticipantList = new List<CourseParticipant>(),
                    VerificationList = new List<Verification>(),
                    Year = 2020
                }
              ); //And rest...
            context.SaveChanges();

            return options;
        }
    }
}
