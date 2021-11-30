using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class LeaderRepository : IAppRepository<Leader>
    {
        private readonly AppDbContext database;
        public LeaderRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<Leader> GetAll()
        {
            return database.Leaders.ToList();
        }

        public Leader GetById(Guid id)
        {
            return database.Leaders
                .Include(leader=>leader.CourseList)
                .ThenInclude(courseLeader => courseLeader.Leader)
                .ThenInclude(leader => leader.ScheduleData)
                .Include(leader => leader.User)
                .Include(leader=> leader.VerificationList)
                .ThenInclude(verification => verification.Competence)
                .FirstOrDefault(leader => leader.Id == id);
        }

        public Guid Create(Leader leader)
        {
            database.Leaders.Add(leader);
            database.SaveChanges();
            return leader.Id;
        }

        public void Delete(Guid id)
        {
            var leader = database.Leaders.FirstOrDefault(leader => leader.Id == id);
            if (leader != null)
            {
                database.Leaders.Remove(leader);
                database.SaveChanges();
            }
        }

        public Guid Update(Leader leader)
        {
            var leaderForUpdate = database.Leaders.Attach(leader);
            leaderForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return leader.Id;
        }
    }
}

