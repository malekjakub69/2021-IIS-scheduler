using System.Collections.Generic;
using AppEntities.Enums;

namespace AppEntities.Entities
{
    public class Course: EntityBase
    {
        public int Year { get; set; }

        public string Name { get; set; }

        public CoursesType Type { get; set; }

        //relationships

        // N:1
        public List<Schedule> ScheduleList { get; set; }
        // N:M
        public List<CourseParticipant> ParticipantList { get; set; }
        // N:1
        public List<Done> DoneList { get; set; }
        // N:1 
        public List<Verification> VerificationList { get; set; }
        // N:M    
        public List<CourseLeader> LeaderList { get; set; }
    }
}