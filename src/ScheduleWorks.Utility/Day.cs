using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
	[Serializable]
    public class Day
    {
        private List<ClassSchedule> mClasses;

        public Day(List<ClassSchedule> classes)
        {
            this.mClasses = classes;
        }

        public List<ClassSchedule> Classes
        {
            get
            {
                return this.mClasses;
            }
        }
    }
}
