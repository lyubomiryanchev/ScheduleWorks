using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Algorithm
{
    public class Rating
    {
		public int DifficultyPatternMatching;
		public int TeachersPatternMatchin;
		public int RequirementsFulfil
		{
			get
			{
				return DifficultyPatternMatching + TeachersPatternMatchin;
			}
		}
        public int Errors;
    }
}
