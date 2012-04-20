using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ScheduleWorks.Utility
{
    [Serializable()]
    public class Class
    {
        private int mID;
        private string mDivision;
		private string mName;
        private BasicClass mBasicClass;
        private List<ClassDetails> mDetails;
        private bool mDetailsSet;

        public Class(string aName, string aShortName, int aGrade,
                     Color aColor, long aHeadTeacherIndexInTheDB)
        {
            Name = aName;
            ShortName = aShortName;
            Grade = aGrade;
            Color = aColor;
            HeadTeacherID = aHeadTeacherIndexInTheDB;
            this.Groups = new List<string>();

            mID = IndexMaker.Class();
        }

        public Class(int id, string division, BasicClass basicClass)
        {
            this.mID = id;
            this.mDivision = division;
            this.mBasicClass = basicClass;
			this.mName = mBasicClass.NameWithRomeDigits + " " + division;
			int grade;
			int.TryParse(mBasicClass.NameWithDigits, out grade);
			this.Grade = grade;
            this.Groups = new List<string>();
            //this.mDetails = new List<ClassDetails> { };
            //this.mDetails = details.Select(x => x).ToList<ClassDetails>();
        }

        public Class(int id, string division, BasicClass basicClass, List<ClassDetails> details)
        : this(id, division, basicClass)
        {
            this.mDetails = details.Select(x => x.DeepCopy()).ToList();
            this.Groups = new List<string>();
        }

		public override string ToString()
		{
			return this.Name;
		}

        public void SetDetails(List<ClassDetails> details)
        {
            if (!this.mDetailsSet)
            {
                this.mDetails = details.Select(x => x.DeepCopy()).ToList();
                this.mDetailsSet = true;
            }
        }

        public Class ShallowCopy()
        {
            return (Class)this.MemberwiseClone();
        }


        public TimeOffEnum[,] Timeoff = new TimeOffEnum[Consts.TimeOffEnumSize, Consts.TimeOffEnumSize];


		public string Name
		{
			get
			{
				return this.mName;
			}
			set
			{
				this.mName = value;
			}
		}

        public string ShortName { get; set; }

        public int Grade { get; set; }

        public Color Color { get; set; }

        public long HeadTeacherID { get; set; }

        public int ID
        {
            get
            {
                return this.mID;
            }

            set
            {
                this.mID = value;
            }
        }

        public string Division
        {
            get
            {
                return this.mDivision;
            }
            set
            {
                this.mDivision = value;
            }
        }

        public List<ClassDetails> Details
        {
            get
            {
                if (!this.mDetailsSet) throw new NullReferenceException("Details property of Class is null");
				return this.mDetails;
            }
        }

        public BasicClass BClass
        {
            get
            {
                return this.mBasicClass;
            }
        }

        public List<string> Groups;
    }
}
