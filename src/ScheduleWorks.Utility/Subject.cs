using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ScheduleWorks.Utility;


namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class Subject
    {
		public Subject()
		{

		}
        public Subject(int aID, string aName, SubjectGroup aGroup)
        {
            ID = aID;
            Name = aName;
            ShortName = Name.Substring(0, 3);
            Group = aGroup;
        }
        public Subject(string aName, string aShortName, Color aColor, RelativeSubjectDifficulty aDifficulty)
        {
            Name = aName;
            ShortName = aShortName;
            Color = aColor;
            Difficulty = aDifficulty;

            ID = IndexMaker.Subject();
        }

		public override string ToString()
		{
			return this.ShortName;
		}

        public TimeOffEnum[,] Timeoff = new TimeOffEnum[Consts.TimeOffEnumSize, Consts.TimeOffEnumSize];

        public int ID
        {
            get;
            set;
        }
    
        public string Name
        {
            get;
            set;
        }

        public string ShortName
        {
            get;
            set;
        }

        public Color Color
        {
            get;
            set;
        }

        public RelativeSubjectDifficulty Difficulty
        {
            get;
            set;
        }
        public SubjectGroup Group
        {
            get;
            set;
        }
    }
}
