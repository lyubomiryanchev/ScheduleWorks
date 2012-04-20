using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class Classroom
    {
        public Classroom(string aName, string aShortname, Color aColor,
            bool aIsHomeClassroom, long aHomeClassID,
            bool aIsSpecialisated, List<long> aSpecialisationsIDs)
        {
            Name = aName;
            ShortName = aShortname;
            Color = aColor;

            IsHomeClassroom = aIsHomeClassroom;
            
            HomeClassID = aHomeClassID;

            IsSpecialisated = aIsSpecialisated;
            SpecialisatedSubjectsIDs = aSpecialisationsIDs;

            ID = IndexMaker.Classroom();
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

        public bool IsHomeClassroom
        {
            get;
            set;
        }

        public bool IsSpecialisated
        {
            get;
            set;
        }

        public long HomeClassID
        {
            get;
            set;
        }

        public List<long> SpecialisatedSubjectsIDs
        {
            get;
            set;
        }
    }
}
