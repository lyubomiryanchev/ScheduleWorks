using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    public static class IndexMaker
    {
        public static int LastIndexOfTeachers = -1;
        public static int LastIndexOfSubjects = -1;
        public static int LastIndexOfClassrooms = -1;
        public static int LastIndexOfClasses = -1;
        public static int LastIndexOfLessons = -1;

        public static int Subject()
        {
            LastIndexOfSubjects++;
            return LastIndexOfSubjects;
        }

        public static int Teacher()
        {
            LastIndexOfTeachers++;
            return LastIndexOfTeachers;
        }

        public static int Classroom()
        {
            LastIndexOfClassrooms++;
            return LastIndexOfClassrooms;
        }

        public static int Class()
        {
            LastIndexOfClasses++;
            return LastIndexOfClasses;
        }

        public static int Lesson()
        {
            LastIndexOfLessons++;
            return LastIndexOfLessons;
        }
    }
}
