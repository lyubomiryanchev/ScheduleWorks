using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class SubjectGroup
    {
        public SubjectGroup(int aID, string aName, int aNorma)
        {
            ID = aID;
            Name = aName;
            NormaBasic = aNorma;
        }
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
        public int NormaBasic
        {
            get;
            set;
        }
    }
}
