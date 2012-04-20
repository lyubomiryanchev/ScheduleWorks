using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleWorks.Utility;

namespace ScheduleWorks.Utility
{
	[Serializable()]
    public class ClassSchedule
    {
        private List<Lesson> mLessons;
        private Class mClass;

        public ClassSchedule(Class aClass, List<Lesson> lessons)
        {
            this.mLessons = lessons;
            this.mClass = aClass;
        }

        public List<Lesson> Lessons
        {
            get
            {
                return this.mLessons;
            }
        }
        public Class Class
        {
            get
            {
                return this.mClass;
            }
            set
            {
                this.mClass = value;
            }
        }
    }
}
