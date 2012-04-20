using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class ClassType
    {
        private int mClassTypeID;
        private string mClassTypeName;
        private string mClassTypeShortName;

        public ClassType() { }
        public ClassType(int id, string name, string shortName)
        {
            this.mClassTypeID = id;
            this.mClassTypeName = name;
            this.mClassTypeShortName = shortName;
        }
        public ClassType DeepCopy()
        {
            return new ClassType(this.mClassTypeID, this.mClassTypeName, this.mClassTypeShortName);
        }
        public ClassType ShallowCopy()
        {
            return (ClassType)this.MemberwiseClone();
        }

        public int ID
        {
            get
            {
                return this.mClassTypeID;
            }
        }
        public string Name
        {
            get
            {
                return this.mClassTypeName;
            }
        }
        public string ShortName
        {
            get
            {
                return this.mClassTypeShortName;
            }
        }
    }
}
