using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Migrations;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CourseLeaderRepository: IAppRepository<CourseLeader>
    {
        private readonly AppDbContext database;
        public CourseLeaderRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<CourseLeader> GetAll()
        {
            return database.CourseLeader.ToList();
        }

        public CourseLeader GetById(Guid id)
        {
            return database.CourseLeader
                .Include(courseLeader => courseLeader.Course)
                .Include(courseLeader => courseLeader.Leader)
                .FirstOrDefault(courseLeader => courseLeader.Id == id);
        }

        public Guid Create(CourseLeader courseLeader)
        {
            database.CourseLeader.Add(courseLeader);
            database.SaveChanges();
            return courseLeader.Id;
        }

        public void Delete(Guid id)
        {
            var course = database.Courses.FirstOrDefault(courseLeader => courseLeader.Id == id);
            if (course != null)
            {
                database.Courses.Remove(course);
                database.SaveChanges();
            }
        }

        public Guid Update(CourseLeader courseLeader)
        {
            var courseForUpdate = database.CourseLeader.Attach(courseLeader);
            courseForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return courseLeader.Id;
        }
    }
}