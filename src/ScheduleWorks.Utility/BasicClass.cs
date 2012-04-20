using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class BasicClass
    {
        private int mID;
        private string mNameWithDigits;
        private string mNameWithRomeDigits;
        private string mNameWithWords;

        public BasicClass(int id, string nameWithDigits, string nameWithWords, string romeDigits)
        {
            this.mID = id;
            this.mNameWithDigits = nameWithDigits;
            this.mNameWithWords = nameWithWords;
            this.mNameWithRomeDigits = romeDigits;
        }
        public BasicClass ShallowCopy()
        {
            return (BasicClass)this.MemberwiseClone();
        }

        public int ID
        {
            get
            {
                return this.mID;
            }
        }
        public string NameWithDigits
        {
            get
            {
                return this.mNameWithDigits;
            }
        }
        public string NameWithRomeDigits
        {
            get
            {
                return this.mNameWithRomeDigits;
            }
        }
        public string NameWithWords
        {
            get
            {
                return this.mNameWithWords;
            }
        }
    }
}
