using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleWorks.Utility;

namespace ScheduleWorks.Utility
{
	[Serializable]
	public class Group
	{
		private Teacher mTeacher;
		private ClassDetails mGroup;
		private Classroom mDesiredRoom;
		private Classroom mRoom;
		private List<Classroom> mAlternativeRooms;

		public Group(Teacher teacher, ClassDetails group, Classroom desiredRoom, List<Classroom> alternativeRooms)
		{
			this.mTeacher = teacher;
			this.mGroup = group;
			this.mDesiredRoom = desiredRoom;
			this.mRoom = desiredRoom;
			this.mAlternativeRooms = alternativeRooms;
		}

		public Teacher Teacher
		{
			get
			{
				return this.mTeacher;
			}
		}

		public ClassDetails ClassGroup
		{
			get
			{
				return this.mGroup;
			}
		}

		public Classroom DesiredRoom
		{
			get
			{
				return this.mDesiredRoom;
			}
		}

		public Classroom Room
		{
			get
			{
				return this.mRoom;
			}
			set
			{
				this.mRoom = value;
			}
		}

		public List<Classroom> AlternativeRooms
		{
			get
			{
				return this.mAlternativeRooms;
			}
		}
	}
}
