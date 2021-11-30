using System;
using System.Collections.Generic;

namespace AppEntities.Entities
{
    public class Schedule: EntityBase
    {

        public string Name { get; set; }
        //relationships

        // 1:N
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        // N:1
        public List<TimeBlock> TimeBlockList { get; set; }
    }
}