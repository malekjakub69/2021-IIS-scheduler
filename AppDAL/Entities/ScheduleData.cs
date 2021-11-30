using System;

namespace AppEntities.Entities
{
    public class ScheduleData: EntityBase
    {
        
        //relationships
        
        // 1:N        
        public Guid LeaderId { get; set; }
        public Leader Leader { get; set; }
        // 1:N
        public Guid CompetenceId { get; set; }
        public Competence Competence { get; set; }
        // 1:N
        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; }
        // 1:N
        public Guid TimeBlockId { get; set; }
        public TimeBlock TimeBlock { get; set; }

    }
}