using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleWorks.Utility;

namespace ScheduleWorks.Utility
{
	[Serializable()]
    public class Lesson
    {
        private List<Group> mTeachers;
        private Class mClass;
        private Subject mSubject;

        public Lesson(Class aClass, Subject subject, List<Group> groups)
        {
            this.mTeachers = groups;
            this.mClass = aClass;
            this.mSubject = subject;
        }

		public override string  ToString()
		{
			return mSubject.Name;
		}
		public override bool Equals(object obj)
		{
			Lesson b = obj as Lesson;
			bool answer = this.Subject.Equals(b.Subject) &&
						  this.Class.Equals(b.Class) &&
						  this.Groups.Count == b.Groups.Count;

			if (answer == false) return false;

			for (int i = 0; i < this.Groups.Count; ++i)
			{
				answer = answer && this.Groups[i].Teacher.Equals(b.Groups[i].Teacher);
			}
			return answer;
		}
		public override int GetHashCode()
		{
			return (mSubject.GetHashCode().ToString() + mClass.GetHashCode().ToString()).GetHashCode();
		}

        public List<Group> Groups
        {
            get
            {
                return this.mTeachers;
            }
        }
        public Class Class
        {
            get
            {
                return this.mClass;
            }
        }
        public Subject Subject
        {
            get
            {
                return this.mSubject;
            }
        }
    }
}
