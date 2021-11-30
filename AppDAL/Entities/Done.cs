using System;

namespace AppEntities.Entities
{
    public class Done: EntityBase
    {

        //relationships

        // 1:N
        public Guid CompetenceId { get; set; }
        public Competence Competence { get; set; }
        // 1:N
        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; }
        // 1:N
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}