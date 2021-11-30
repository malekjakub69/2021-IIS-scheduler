using System;
using System.Collections.Generic;

namespace AppEntities.Entities
{
    public class Leader: EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }
        
        //relationships
        // N:1
        public List<ScheduleData> ScheduleData { get; set; }
        // N:1
        public List<Verification> VerificationList { get; set; }
        // N:M
        public List<CourseLeader> CourseList { get; set; }
        // 1:1
        public User User { get; set; }
    }
}