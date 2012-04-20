using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class Teacher
    {
        public Teacher(long aID, string aFirstName, string aMidName, string aLastName, Gender aGender)
        {
            ID = aID;
            FirstName = aFirstName;
            MidName = aMidName;
            LastName = aLastName;
            Gender = aGender;
            ShortName = aFirstName[0] + "" + aLastName[0];
            Name = FirstName + " " + MidName + " " + LastName;
        }
        public Teacher(string aName, string aShortName, Color aColor, Gender aGender)
        {
            Name = aName;
            ShortName = aShortName;
            Color = aColor;
            Gender = aGender;

            ID = IndexMaker.Teacher();
        }

        public TimeOffEnum[,] Timeoff = new TimeOffEnum[Consts.TimeOffEnumSize, Consts.TimeOffEnumSize];

        public long ID
        {
            get;
            set;
        }
    
        public string Name
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }
        public string MidName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }

        public string ShortName
        {
            get;
            set;
        }

        public bool IsColorAssigned
        {
            get
            {
                return Color != null;
            }
        }

        public Color Color
        {
            get;
            set;
        }

        public Gender Gender
        {
            get;
            set;
        }
    }
}
