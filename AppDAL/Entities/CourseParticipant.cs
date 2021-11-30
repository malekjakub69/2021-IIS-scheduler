using System;

namespace AppEntities.Entities
{
    public class CourseParticipant : EntityBase
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        
        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; }
        
    }
}