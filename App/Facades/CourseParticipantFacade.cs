using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.CourseParticipants;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class CourseParticipantFacade : IAppFacade
    {
        public readonly CourseParticipantRepository CourseParticipantRepository;
        public readonly IMapper Mapper;

        public CourseParticipantFacade(CourseParticipantRepository courseParticipantRepository,
            IMapper mapper)
        {
            this.CourseParticipantRepository = courseParticipantRepository;
            this.Mapper = mapper;
        }

        public List<CourseParticipantListModel> GetAll()
        {
            return Mapper.Map<List<CourseParticipantListModel>>(CourseParticipantRepository.GetAll());
        }

        public CourseParticipantDetailModel GetById(Guid id)
        {
            return Mapper.Map<CourseParticipantDetailModel>(CourseParticipantRepository.GetById(id));
        }

        public Guid Create(CourseParticipantNewModel courseParticipant)
        {
            var courseParticipantEntity = Mapper.Map<CourseParticipant>(courseParticipant);
            return CourseParticipantRepository.Create(courseParticipantEntity);
        }

        public Guid? Update(CourseParticipantUpdateModel courseParticipant)
        {
            var courseParticipantEntity = Mapper.Map<CourseParticipant>(courseParticipant);
            return CourseParticipantRepository.Update(courseParticipantEntity);
        }

        public void Delete(Guid id)
        {
            CourseParticipantRepository.Delete(id);
        }

    }
}
