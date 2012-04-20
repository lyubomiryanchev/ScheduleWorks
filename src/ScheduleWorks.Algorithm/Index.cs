using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Algorithm
{
    enum Parent {
        FirstParent,
        SecondParent
    }
    class Index
    {
		public int Day { get; set; }
		public int ClassN { get; set; }
		public int Period { get; set; }

        public Index(int day, int classN, int period)
        {
            this.Day = day;
            this.ClassN = classN;
            this.Period = period;
        }
    }
}
