using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class EducationForm
    {
        private int mID;
        private string mName;
        private string mShortName;

        public EducationForm(int id, string name, string shortName)
        {
            this.mID = id;
            this.mName = name;
            this.mShortName = shortName;
        }
        public EducationForm ShallowCopy()
        {
            return (EducationForm)this.MemberwiseClone();
        }

        public int ID
        {
            get
            {
                return this.mID;
            }
        }
        public string Name
        {
            get
            {
                return this.mName;
            }
        }
        public string ShortName
        {
            get
            {
                return this.mShortName;
            }
        }
    }
}
