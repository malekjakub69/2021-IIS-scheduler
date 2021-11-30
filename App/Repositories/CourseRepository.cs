using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class CourseRepository : IAppRepository<Course>
    {
        private readonly AppDbContext database;
        public CourseRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<Course> GetAll()
        {
            return database.Courses.ToList();
        }

        public Course GetById(Guid id)
        {
            return database.Courses
                .Include(course => course.ParticipantList)
                .ThenInclude(participant => participant.Participant)
                .ThenInclude(participant => participant.ScheduleData)
                .Include(course => course.ParticipantList)
                .ThenInclude(participant => participant.Participant)
                .ThenInclude(participant => participant.DoneList)
                .Include(course => course.LeaderList)
                .ThenInclude(leader=> leader.Leader)
                .ThenInclude(leader => leader.ScheduleData)
                .Include(course => course.ScheduleList)
                .ThenInclude(schedule => schedule.TimeBlockList )
                .FirstOrDefault(course => course.Id == id);
        }

        public Guid Create(Course course)
        {
            database.Courses.Add(course);
            database.SaveChanges();
            return course.Id;
        }

        public void Delete(Guid id)
        {
            var course = database.Courses.FirstOrDefault(course => course.Id == id);
            if (course != null)
            {
                database.Courses.Remove(course);
                database.SaveChanges();
            }
        }

        public Guid Update(Course course)
        {
            var courseForUpdate = database.Courses.Attach(course);
            courseForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return course.Id;
        }
    }
}

