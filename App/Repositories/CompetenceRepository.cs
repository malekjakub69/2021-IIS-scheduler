using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class CompetenceRepository : IAppRepository<Competence>
    {
        private readonly AppDbContext database;
        public CompetenceRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<Competence> GetAll()
        {
            return database.Competences.ToList();
        }

        public Competence GetById(Guid id)
        {
            return database.Competences.FirstOrDefault(competence => competence.Id == id);
        }

        public Guid Create(Competence competence)
        {
            database.Competences.Add(competence);
            database.SaveChanges();
            return competence.Id;
        }

        public void Delete(Guid id)
        {
            var competence = database.Competences.FirstOrDefault(competence => competence.Id == id);
            if (competence != null)
            {
                database.Competences.Remove(competence);
                database.SaveChanges();
            }
        }

        public Guid Update(Competence competence)
        {
            var competenceForUpdate = database.Competences.Attach(competence);
            competenceForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return competence.Id;
        }
    }
}
