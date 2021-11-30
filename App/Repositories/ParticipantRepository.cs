using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class ParticipantRepository : IAppRepository<Participant>
    {
        private readonly AppDbContext database;
        public ParticipantRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<Participant> GetAll()
        {
            return database.Participants.ToList();
        }

        public Participant GetById(Guid id)
        {
            return database.Participants
                .Include(participant => participant.DoneList)
                .ThenInclude(done => done.Competence)
                .Include(participant => participant.CourseList)
                .ThenInclude(courseParticipant => courseParticipant.Course)
                .Include(participant => participant.User)
                .Include(participant => participant.ScheduleData)
                .FirstOrDefault(participant => participant.Id == id);
        }

        public Guid Create(Participant participant)
        {
            database.Participants.Add(participant);
            database.SaveChanges();
            return participant.Id;
        }

        public void Delete(Guid id)
        {
            var participant = database.Participants.FirstOrDefault(participant => participant.Id == id);
            if (participant != null)
            {
                database.Participants.Remove(participant);
                database.SaveChanges();
            }
        }

        public Guid Update(Participant participant)
        {
            var participantForUpdate = database.Participants.Attach(participant);
            participantForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return participant.Id;
        }
    }
}

