using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class DoneRepository : IAppRepository<Done>
    {
        private readonly AppDbContext database;
        public DoneRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<Done> GetAll()
        {
            return database.Dones.ToList();
        }

        public Done GetById(Guid id)
        {
            return database.Dones.FirstOrDefault(done => done.Id == id);
        }

        public Guid Create(Done done)
        {
            database.Dones.Add(done);
            database.SaveChanges();
            return done.Id;
        }

        public void Delete(Guid id)
        {
            var done = database.Dones.FirstOrDefault(done => done.Id == id);
            if (done != null)
            {
                database.Dones.Remove(done);
                database.SaveChanges();
            }
        }

        public Guid Update(Done done)
        {
            var doneForUpdate = database.Dones.Attach(done);
            doneForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return done.Id;
        }
    }
}

