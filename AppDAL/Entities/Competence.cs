using System.Collections.Generic;
using AppEntities.Enums;

namespace AppEntities.Entities
{
    
    public class Competence: EntityBase
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public CoursesType Type { get; set; }
        
        //relationships

        // N:1
        public List<Done> DoneList { get; set; }
        // N:1
        public List<Verification> VerificationsList { get; set; }
        // N:1
        public List<ScheduleData> ScheduleDataList { get; set; }

    }
}