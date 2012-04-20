using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;

namespace ScheduleWorks.Utility
{
	public delegate void RemovedEvent(object obj);
    [Serializable()]
	class ListClassesDeletedEvent<T> : IList<T>
	{
		private List<T> list;

		public ListClassesDeletedEvent()
		{
			list = new List<T>();
		}
		public ListClassesDeletedEvent(List<T> l)
		{
			list = l;
		}
		public event RemovedEvent Removed;
		public void Add(T item)
		{
			this.list.Add(item);
		}
		public bool Remove(T obj)
		{
			if (Removed != null)
			{
				this.Removed(obj);
			}
			return list.Remove(obj);
		}
		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}
		public T this[int index]
		{
			set
			{
				list[index] = value;
			}
			get
			{
				return list[index];
			}
		}
		public bool Contains(T item)
		{
			return list.Contains(item);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}
		public IEnumerator<T> GetEnumerator()
		{
			return list.GetEnumerator();
		}
		public void CopyTo(T[] arr, int index)
		{
			list.CopyTo(arr, index);
		}
		public int IndexOf(T item)
		{
			return list.IndexOf(item);
		}
		public void Clear()
		{
			list.Clear();
		}
		public void Insert(int index, T item)
		{
			list.Insert(index, item);
		}
		public void CopyTo(T[] arr)
		{
			list.CopyTo(arr);
		}
		
		public int Count
		{
			get
			{
				return this.list.Count;
			}
		}
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}
	}

    [Serializable()]
    public class DBManager
    {
		private List<Classroom> mClassrooms;
		private ListClassesDeletedEvent<Class> mClasses;

        public AlgorithmParameters AlgorithmParameters = new AlgorithmParameters();

        public DBManager()
        {
            isAddedInformationThroughTheWizard = false;
            Classrooms = new List<Classroom>();
            mClasses = new ListClassesDeletedEvent<Class>();
			mClasses.Removed += new RemovedEvent(this.ClassRemoved);
			//Classes = new List<Class>();
            Subjects = new List<Subject>();
            Teachers = new List<Teacher>();
            Lessons = new List<Curriculum>();
        }

		public List<Classroom> Classrooms
		{
			get
			{
				return this.mClassrooms;
			}
			set
			{
				this.mClassrooms = value;
			}
		}
		public IList<Class> Classes
		{
			get
			{
				return this.mClasses;
			}
			set
			{
				this.mClasses = (ListClassesDeletedEvent<Class>)value;
			}
		}
		public List<Subject> Subjects;
		public List<Teacher> Teachers;
		public List<Curriculum> Lessons;
		public List<Day> Timetable;
        public string SchoolName;
        public string AcademicYear;
        public string DBImportPath;
        public bool isAddedInformationThroughTheWizard;

		private Class Removed;

		private void ClassRemoved(object obj)
		{
			Class cl = (Class)obj;
			Removed = cl;
			Lessons.RemoveAll(new Predicate<Curriculum>(ToRemove));
			Removed = null;
		}
		private bool ToRemove(Curriculum c)
		{
			return c.Class.Equals(Removed);
		}
    }
}
