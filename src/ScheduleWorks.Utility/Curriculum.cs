using System;
using System.Collections.Generic;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class Curriculum
    {
        #region Members


        private Teacher mTeacher;
        private Subject mSubject;
        private Class mClass;
        private Classroom mDesiredClassroom;
        private int mHoursPerWeek;
        private HourLenght mHourLenght;
        private ClassDetails mGroup;
        private int mID;
        

        #endregion

        #region Constructors

        public Curriculum(int id, Subject aSubject, Class aClass, ClassDetails aGroup, Teacher aTeacher, int hoursPerWeek)
        {
            this.mID = id;
            this.mSubject = aSubject;
            this.mClass = aClass;
            this.mGroup = aGroup;
            this.mTeacher = aTeacher;
            this.mHoursPerWeek = hoursPerWeek;
            this.mHourLenght = Utility.HourLenght.NoMatter;
        }

        public Curriculum(Teacher aTeacher, Subject aSubject, Class aClass, Classroom aDesiredClassroom, HourLenght aHourLenght, int aHoursPerWeek)
        {
            mID = IndexMaker.Lesson();

            this.mTeacher = aTeacher;
            this.mSubject = aSubject;
            this.mClass = aClass;
            this.mTeacher = aTeacher;
            this.mHourLenght = aHourLenght;
            this.mHoursPerWeek = aHoursPerWeek;
            this.mDesiredClassroom = aDesiredClassroom;
            this.mHourLenght = Utility.HourLenght.NoMatter;
        }

        public Curriculum(Teacher aTeacher, Subject aSubject, Class aClass, Classroom aDesiredClassroom, List<Classroom> aAlternativeClassrooms, HourLenght aHourLenght, int aHoursPerWeek)
        {
            mID = IndexMaker.Lesson();

            this.mTeacher = aTeacher;
            this.mSubject = aSubject;
            this.mClass = aClass;
            this.mTeacher = aTeacher;
            this.mHourLenght = Utility.HourLenght.NoMatter;
            this.mHoursPerWeek = aHoursPerWeek;
            this.mDesiredClassroom = aDesiredClassroom;
            this.AlternativeClassrooms = aAlternativeClassrooms;
        }

        #endregion

        #region Properties

        public List<Classroom> AlternativeClassrooms = new List<Classroom>();

        public TimeOffEnum[,] Timeoff = new TimeOffEnum[Consts.TimeOffEnumSize, Consts.TimeOffEnumSize];

        public Subject Subject
        {
            set
            {
                mSubject = value;
            }
            get
            {
                return this.mSubject;
            }
        }

        public Class Class
        {
            set
            {
                mClass = value;
            }
            get
            {
                return this.mClass;
            }
        }

        public ClassDetails Group
        {
            set
            {
                mGroup = value;
            }
            get
            {
                return this.mGroup;
            }
        }

        public Teacher Teacher
        {
            set
            {
                mTeacher = value;
            }
            get
            {
                return this.mTeacher;
            }
        }
        
        public int HoursPerWeek{
            get
            {
                return mHoursPerWeek;
            }
            set
            {
                mHoursPerWeek = value;
            }
        }

        public HourLenght HourLenght 
        {
            get
            {
                return mHourLenght;
            }
            set
            {
                mHourLenght = value;
            }
        }

        public Classroom DesiredClassroom
        {
            get
            {
                return mDesiredClassroom;
            }
            set
            {
                mDesiredClassroom = value;
            }
        }

        public int ID
        {
            get
            {
                return this.mID;
            }
            set
            {
                mID = value;
            }
        }

        #endregion
    }
}
