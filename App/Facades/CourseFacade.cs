using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.Courses;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class CourseFacade : IAppFacade
    {
        public readonly CourseRepository CourseRepository;
        public readonly IMapper Mapper;

        public CourseFacade(CourseRepository courseRepository,
            IMapper mapper)
        {
            this.CourseRepository = courseRepository;
            this.Mapper = mapper;
        }

        public List<CourseListModel> GetAll()
        {
            return Mapper.Map<List<CourseListModel>>(CourseRepository.GetAll());
        }

        public CourseDetailModel GetById(Guid id)
        {
            return Mapper.Map<CourseDetailModel>(CourseRepository.GetById(id));
        }

        public Guid Create(CourseNewModel course)
        {
            var courseEntity = Mapper.Map<Course>(course);
            return CourseRepository.Create(courseEntity);
        }

        public Guid? Update(CourseUpdateModel course)
        {
            var courseEntity = Mapper.Map<Course>(course);
            return CourseRepository.Update(courseEntity);
        }

        public void Delete(Guid id)
        {
            CourseRepository.Delete(id);
        }

    }
}
