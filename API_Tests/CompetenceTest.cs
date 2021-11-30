using AppEntities.Entities;
using API_Tests.Fixtures;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using App.Repositories;
using App.Migrations;
using System.Threading.Tasks;
using System.Net;
using System;

namespace API_Tests
{
    public class CompetenceTest : IntegrationTest
    {
        public CompetenceTest(AppFactory fixture) : base(fixture)
        {

        }

        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            var context = new AppDbContext(SetupDbContextOptions());

            //Act
            CompetenceRepository competenceRepository = new CompetenceRepository(context);
            List<Competence> competences = (List<Competence>)competenceRepository.GetAll();

            //Assert
            competences.Should().HaveCount(1);
            competences[0].Name.Should().Be("Competence Test");
        }

        [Fact]
        public void GetByIdTest()
        {
            //Arrange
            var context = new AppDbContext(SetupDbContextOptions());

            //Act
            CompetenceRepository competenceRepository = new CompetenceRepository(context);
            Competence competence = competenceRepository.GetById(new Guid("15949177-2e41-4e1d-8b6f-7d50ac8190cf"));

            //Assert
            competence.Should().NotBeNull();
            competence.Name.Should().Be("Competence Test");
        }
    }
}
