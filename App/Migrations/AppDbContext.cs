using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AppEntities.Entities;

namespace App.Migrations
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Competence> Competences { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLeader> CourseLeader { get; set; }
        public DbSet<CourseParticipant> CourseParticipant { get; set; }
        public DbSet<Done> Dones { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleData> ScheduleDatas { get; set; }
        public DbSet<TimeBlock> TimeBlocks { get; set; }
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<User> SchedulerUsers { get; set; }

    }
}
