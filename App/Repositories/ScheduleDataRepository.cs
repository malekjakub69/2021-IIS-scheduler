using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class ScheduleDataRepository : IAppRepository<ScheduleData>
    {
        private readonly AppDbContext database;
        public ScheduleDataRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<ScheduleData> GetAll()
        {
            return database.ScheduleDatas
                .Include(scheduleData => scheduleData.Leader)
                .Include(scheduleData => scheduleData.Participant)
                .Include(scheduleData => scheduleData.TimeBlock)
                .Include(scheduleData => scheduleData.Competence)
                .ToList();
        }

        public ScheduleData GetById(Guid id)
        {
            return database.ScheduleDatas
                .Include(scheduleData => scheduleData.Leader)
                .Include(scheduleData => scheduleData.Participant)
                .Include(scheduleData => scheduleData.TimeBlock)
                .Include(scheduleData => scheduleData.Competence)
                .FirstOrDefault(scheduleData => scheduleData.Id == id);
        }

        public Guid Create(ScheduleData scheduleData)
        {
            database.ScheduleDatas.Add(scheduleData);
            database.SaveChanges();
            return scheduleData.Id;
        }

        public void Delete(Guid id)
        {
            var scheduleData = database.ScheduleDatas.FirstOrDefault(scheduleData => scheduleData.Id == id);
            if (scheduleData != null)
            {
                database.ScheduleDatas.Remove(scheduleData);
                database.SaveChanges();
            }
        }

        public Guid Update(ScheduleData scheduleData)
        {
            var scheduleDataForUpdate = database.ScheduleDatas.Attach(scheduleData);
            scheduleDataForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return scheduleData.Id;
        }
    }
}

