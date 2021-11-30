using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AppEntities.Entities
{ 
    public class TimeBlock: EntityBase
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        
        //relationships
        // 1:N
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        // N:1
        public List<ScheduleData> ScheduleDataList { get; set; }
    }
}