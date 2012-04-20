using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class ClassDetails
    {
        private int mID;
        private int mGroup;
        private ClassType mType;
        private BasicClass mBClass;
        private EducationForm mEducationForm;
        private Class mDetailed;

        private bool mIsDetailedSet;

        public ClassDetails(int id, int group, ClassType type, BasicClass bclass, EducationForm educationform)
        {
            this.mID = id;
            this.mGroup = group;
            this.mType = type;
            this.mBClass = bclass;
            this.mEducationForm = educationform;
            //this.mDetailed = detailed;
        }
        public ClassDetails(int id, int group, ClassType type, BasicClass bclass, EducationForm educationform, Class detailed)
            : this(id, group, type, bclass, educationform)
        {
            this.SetDetailed(detailed);
        }
        public void SetDetailed(Class detailed)
        {
            if (!this.mIsDetailedSet)
            {
                this.mDetailed = detailed;
                this.mIsDetailedSet = true;
            }
        }

        public ClassDetails DeepCopy()
        {
            return new ClassDetails(this.mID, this.mGroup, this.mType.ShallowCopy(), mBClass.ShallowCopy(), mEducationForm.ShallowCopy(), mDetailed);
        }
        public ClassDetails ShallowCopy()
        {
            return (ClassDetails)this.MemberwiseClone();
        }

        public int ID
        {
            get
            {
                return this.mID;
            }
        }
        public int Group
        {
            get
            {
                return this.mGroup;
            }
        }
        public ClassType Type
        {
            get
            {
                return this.mType;
            }
        }
        public BasicClass BClass
        {
            get
            {
                return this.mBClass;
            }
        }
        public EducationForm FormOfEducation
        {
            get
            {
                return this.mEducationForm;
            }
        }
        public Class Detailed
        {
            get
            {
                if (!mIsDetailedSet) throw new NullReferenceException("Detailed Class hasn't been set");
                return this.mDetailed;
            }
        }
    }
}
