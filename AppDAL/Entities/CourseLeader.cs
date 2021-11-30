using System;

namespace AppEntities.Entities
{
    public class CourseLeader: EntityBase
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        
        public Guid LeaderId { get; set; }
        public Leader Leader { get; set; }
    }
}