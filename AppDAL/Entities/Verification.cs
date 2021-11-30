using System;

namespace AppEntities.Entities
{
    public class Verification: EntityBase
    {

        //relationships

        // 1:N
        public Guid CompetenceId { get; set; }
        public Competence Competence { get; set; }
        // 1:N
        public Guid LeaderId { get; set; }
        public Leader Leader { get; set; }
        // 1:N
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}