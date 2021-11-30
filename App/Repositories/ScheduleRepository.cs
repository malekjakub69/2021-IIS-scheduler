using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class ScheduleRepository : IAppRepository<Schedule>
    {
        private readonly AppDbContext database;
        public ScheduleRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<Schedule> GetAll()
        {
            return database.Schedules.ToList();
        }

        public Schedule GetById(Guid id)
        {
            return database.Schedules
                .Include(schedule => schedule.Course)
                .Include(schedule => schedule.TimeBlockList)
                .ThenInclude(timeBlock => timeBlock.ScheduleDataList)
                .ThenInclude(dataList => dataList.Competence)
                .Include(schedule => schedule.TimeBlockList)
                .ThenInclude(timeBlock => timeBlock.ScheduleDataList)
                .ThenInclude(dataList => dataList.Leader)
                .Include(schedule => schedule.TimeBlockList)
                .ThenInclude(timeBlock => timeBlock.ScheduleDataList)
                .ThenInclude(dataList => dataList.Participant)
                .FirstOrDefault(schedule => schedule.Id == id);
        }

        public Guid Create(Schedule schedule)
        {
            database.Schedules.Add(schedule);
            database.SaveChanges();
            return schedule.Id;
        }

        public void Delete(Guid id)
        {
            var schedule = database.Schedules.FirstOrDefault(schedule => schedule.Id == id);
            if (schedule != null)
            {
                database.Schedules.Remove(schedule);
                database.SaveChanges();
            }
        }

        public Guid Update(Schedule schedule)
        {
            var scheduleForUpdate = database.Schedules.Attach(schedule);
            scheduleForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return schedule.Id;
        }
    }
}

