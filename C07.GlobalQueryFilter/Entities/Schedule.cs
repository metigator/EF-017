﻿using C06.CallingTableValuedFunction.Enums;

namespace C06.CallingTableValuedFunction.Entities
{
    public class Schedule : Entity
    {
        public ScheduleType ScheduleType { get; set; }
        public bool SUN { get; set; }
        public bool MON { get; set; }
        public bool TUE { get; set; }
        public bool WED { get; set; }
        public bool THU { get; set; }
        public bool FRI { get; set; }
        public bool SAT { get; set; }

        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}