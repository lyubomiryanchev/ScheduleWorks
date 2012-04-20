using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Algorithm
{
    class ScheduleComparator : EqualityComparer<Schedule>
    {
		private bool HashOnly;
		public ScheduleComparator()
		{
			HashOnly = false;
		}

		public ScheduleComparator(bool arg)
		{
			HashOnly = arg;
		}

        public override bool Equals(Schedule x, Schedule y)
        {
            if (x.GetHashCode() == y.GetHashCode())
            {
                return true;
            }
			if (x.Rating.Errors == y.Rating.Errors && x.Rating.RequirementsFulfil == y.Rating.RequirementsFulfil)
			{
				return true;
			}
			if (!HashOnly)
			{
				
				int cnt = 0;
				for (int day = 0; day < x.Timetable.Count; ++day)
				{
					for (int classN = 0; classN < x.Timetable[day].Classes.Count; ++classN)
					{
						for (int lesson = 0; lesson < x.Timetable[day].Classes[classN].Lessons.Count; lesson++)
						{
							if (x.Timetable[day].Classes[classN].Lessons[lesson] == y.Timetable[day].Classes[classN].Lessons[lesson])
							{
								cnt++;
							}
						}
					}
				}
				if ((double)cnt / (x.Timetable.Count * x.Timetable[0].Classes.Count * x.Timetable[0].Classes[0].Lessons.Count) > 0.75)
				{
					return true;
				}
			}
            return false;
        }
        public override int GetHashCode(Schedule obj)
        {
            return this.GetHashCode();
        }
    }
}
