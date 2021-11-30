using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using App.Migrations;

namespace App.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext database;
        public UserRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<User> GetAll()
        {
            return database.SchedulerUsers.ToList();
        }

        public User GetById(Guid id)
        {
            return database.SchedulerUsers
              .Include(user => user.Leader)
              .Include(user => user.Participant)
              .FirstOrDefault(user => user.Id == id);
        }

        public Guid Create(User user)
        {
            database.SchedulerUsers.Add(user);
            database.SaveChanges();
            return user.Id;
        }

        public void Delete(Guid id)
        {
            var user = database.SchedulerUsers.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                database.SchedulerUsers.Remove(user);
                database.SaveChanges();
            }
        }

        public Guid Update(User user)
        {
            var userForUpdate = database.SchedulerUsers.Attach(user);
            userForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return user.Id;
        }
    }
}

