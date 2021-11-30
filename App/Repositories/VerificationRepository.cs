using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class VerificationRepository : IAppRepository<Verification>
    {
        private readonly AppDbContext database;
        public VerificationRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<Verification> GetAll()
        {
            return database.Verifications.ToList();
        }

        public Verification GetById(Guid id)
        {
            return database.Verifications
                .Include(verification => verification.Competence)
                .Include(verification => verification.Course)
                .Include(verification => verification.Leader)
                .FirstOrDefault(verification => verification.Id == id);
        }

        public Guid Create(Verification verification)
        {
            database.Verifications.Add(verification);
            database.SaveChanges();
            return verification.Id;
        }

        public void Delete(Guid id)
        {
            var verification = database.Verifications.FirstOrDefault(verification => verification.Id == id);
            if (verification != null)
            {
                database.Verifications.Remove(verification);
                database.SaveChanges();
            }
        }

        public Guid Update(Verification verification)
        {
            var verficationForUpdate = database.Verifications.Attach(verification);
            verficationForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return verification.Id;
        }
    }
}
