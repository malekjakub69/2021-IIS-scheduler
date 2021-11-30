using System;
using System.Collections.Generic;

namespace AppEntities.Entities
{
    public class Participant: EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public string Color { get; set; }

        //relationships

        // N:1
        public List<Done> DoneList { get; set; }
        // N:1
        public List<ScheduleData> ScheduleData { get; set; }
        // N:M
        public List<CourseParticipant> CourseList { get; set; }
        // 1:1
        public User User { get; set; }
    }
}