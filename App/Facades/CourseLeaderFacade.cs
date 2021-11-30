using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.CourseLeaders;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class CourseLeaderFacade : IAppFacade
    {
        public readonly CourseLeaderRepository CourseLeaderRepository;
        public readonly IMapper Mapper;

        public CourseLeaderFacade(CourseLeaderRepository courseLeaderRepository,
            IMapper mapper)
        {
            this.CourseLeaderRepository = courseLeaderRepository;
            this.Mapper = mapper;
        }

        public List<CourseLeaderListModel> GetAll()
        {
            return Mapper.Map<List<CourseLeaderListModel>>(CourseLeaderRepository.GetAll());
        }

        public CourseLeaderDetailModel GetById(Guid id)
        {
            return Mapper.Map<CourseLeaderDetailModel>(CourseLeaderRepository.GetById(id));
        }

        public Guid Create(CourseLeaderNewModel courseLeader)
        {
            var courseLeaderEntity = Mapper.Map<CourseLeader>(courseLeader);
            return CourseLeaderRepository.Create(courseLeaderEntity);
        }

        public Guid? Update(CourseLeaderUpdateModel courseLeader)
        {
            var courseLeaderEntity = Mapper.Map<CourseLeader>(courseLeader);
            return CourseLeaderRepository.Update(courseLeaderEntity);
        }

        public void Delete(Guid id)
        {
            CourseLeaderRepository.Delete(id);
        }

    }
}
