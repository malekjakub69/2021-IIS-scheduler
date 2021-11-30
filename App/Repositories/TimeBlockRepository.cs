using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities.Entities;
using Microsoft.EntityFrameworkCore;
using App.Migrations;

namespace App.Repositories
{
    public class TimeBlockRepository : IAppRepository<TimeBlock>
    {
        private readonly AppDbContext database;
        public TimeBlockRepository(AppDbContext database)
        {
            this.database = database;
        }

        public IList<TimeBlock> GetAll()
        {
            return database.TimeBlocks.ToList();
        }

        public TimeBlock GetById(Guid id)
        {
            return database.TimeBlocks
                .Include(timeBlock => timeBlock.ScheduleDataList)
                .ThenInclude(data => data.Competence)
                .Include(timeBlock => timeBlock.ScheduleDataList)
                .ThenInclude(data => data.Participant)
                .Include(timeBlock => timeBlock.ScheduleDataList)
                .ThenInclude(data => data.Leader)
                .FirstOrDefault(timeBlock => timeBlock.Id == id);
        }

        public Guid Create(TimeBlock timeBlock)
        {
            database.TimeBlocks.Add(timeBlock);
            database.SaveChanges();
            return timeBlock.Id;
        }

        public void Delete(Guid id)
        {
            var timeBlock = database.TimeBlocks.FirstOrDefault(timeBlock => timeBlock.Id == id);
            if (timeBlock != null)
            {
                database.TimeBlocks.Remove(timeBlock);
                database.SaveChanges();
            }
        }

        public Guid Update(TimeBlock timeBlock)
        {
            var timeBlockForUpdate = database.TimeBlocks.Attach(timeBlock);
            timeBlockForUpdate.State = EntityState.Modified;
            database.SaveChanges();
            return timeBlock.Id;
        }
    }
}

