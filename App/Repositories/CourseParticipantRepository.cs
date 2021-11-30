using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Migrations;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CourseParticipantRepository: IAppRepository<CourseParticipant>
    {
        private readonly AppDbContext database;
        public CourseParticipantRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<CourseParticipant> GetAll()
        {
            return database.CourseParticipant.ToList();
        }

        public CourseParticipant GetById(Guid id)
        {
            return database.CourseParticipant
                .Include(courseParticipant => courseParticipant.Course)
                .Include(courseParticipant => courseParticipant.Participant)
                .FirstOrDefault(courseParticipant => courseParticipant.Id == id);
        }

        public Guid Create(CourseParticipant courseParticipant)
        {
            database.CourseParticipant.Add(courseParticipant);
            database.SaveChanges();
            return courseParticipant.Id;
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

        public Guid Update(CourseParticipant courseParticipant)
        {
            var courseForUpdate = database.CourseParticipant.Attach(courseParticipant);
            courseForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return courseParticipant.Id;
        }
    }
}

