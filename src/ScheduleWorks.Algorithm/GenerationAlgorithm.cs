using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ScheduleWorks.Utility;

namespace ScheduleWorks.Algorithm 
{
    public class GenerationAlgorithm : ScheduleWorks.Algorithm.IGenerationAlgorithm
    {
        #region Constants
        private const int GenerationSize = 16;
        private const double MutationPercentage = 15.0 / 100;
        private const int MutationsCount = 25;
        #endregion

        #region Members

        private bool mIsInitBegan;
        private bool mIsInitialized;
		private bool mFinished;

        private int mPeriodsCount;
        private int mDaysCount;
        private int mGenerationCycles;

        private List<Schedule> mCurrentGeneration;
		private List<Schedule> mNextGeneration;
        private List<Curriculum> mData;

        private Schedule mSuitingConstraints;
        private Schedule s1;
		private Schedule mLastSuiting;
		private Schedule SaveCopy;

		private int SameRatingCount;

		private AlgorithmParameters mSubjectsDifficulty;

		private Dictionary<Tuple<Class, Subject, List<Group>>, int> compDict;

        #endregion

        #region Constructors

        public GenerationAlgorithm()
        {
            this.mGenerationCycles = 0;
        }

        #endregion

        #region Methods

        public void BeginInit()
        {
            this.mIsInitBegan = true;
        }

        public void EndInit()
        {
            if (this.mIsInitBegan == false)
            {
                throw new GeneticAlgorithmInitializationNotStartedException("EndInit() invoked before BeginInit()");
            }
			try
			{
				this.CheckInitFinished();
			}
			catch (GeneticAlgorithmNotInitializedException e)
			{
				throw new GeneticAlgorithmNotInitializedException("Initialization not completed", e);
			}
            this.mCurrentGeneration = new List<Schedule> { };
            var data = from p in this.mData
                       group p by p.Class into gr
                       select
                       new {
                           Class = gr.Key,
                           Subjects = from t in gr
                                   group t by t.Subject into c
                                   select new { Subject = c.Key, Groups = c }
                       };
            List<Day> timetable = new List<Day>{ };
            for (int i = 0; i < mDaysCount; ++i)
            {
                Day d = new Day(new List<ClassSchedule>{});
                for (int j = 0;j < data.Count(); ++j)
                {
                    List<Lesson> lessons = new List<Lesson>{};
                    for (int k = 0; k < PeriodsCount; ++k)
                    {
                        lessons.Add(null);
                    }
                    ClassSchedule cs = new ClassSchedule(null, lessons);
                    d.Classes.Add(cs);
                }
                timetable.Add(d);
            }
            int day = 0;
            int period = 0;
            int classN = 0;
			int hoursWeekly;
            foreach (var item in data)
            {
                day = 0;
                period = 0;
                for (int i = 0; i < Days; ++i)
                {
                    timetable[i].Classes[classN].Class = item.Class;
                }
				foreach (var current in item.Subjects)
				{
					hoursWeekly = 0;
					List<Group> groups = new List<Group>();
					foreach (Curriculum curric in current.Groups)
					{
						hoursWeekly = curric.HoursPerWeek;
						Group g = new Group(curric.Teacher, curric.Group, curric.DesiredClassroom, curric.AlternativeClassrooms);
						groups.Add(g);
					}
					for (int i = 0; i < hoursWeekly; i++)
					{
						Lesson l = new Lesson(item.Class, current.Subject, groups);
						timetable[day].Classes[classN].Lessons[period] = l;
						if (period == PeriodsCount - 1)
						{
							day++;
							period = 0;
						}
						else
						{
							period++;
						}
					}
				}
                classN++;
            }
			Random rnd = new Random();
            Schedule s = new Schedule(timetable, mSubjectsDifficulty);
			SaveCopy = new Schedule(s.Timetable, mSubjectsDifficulty);
			s.Shuffle(rnd);
            this.mLastSuiting = s;
            this.mSuitingConstraints = s;
            this.mCurrentGeneration.Add(s);
            for (int i = 0; i < GenerationSize * 10; ++i)
            {
                s = new Schedule(timetable, mSubjectsDifficulty);
                s.Shuffle(rnd);
                this.mCurrentGeneration.Add(s);
            }
			EqualityComparer<Schedule> comp = new ScheduleComparator();
			this.mCurrentGeneration = mCurrentGeneration.OrderByDescending(x => x.Rating.Errors).
				Distinct(comp).ToList();
			this.mCurrentGeneration = mCurrentGeneration.GetRange(0, GenerationSize);
            this.mIsInitialized = true;
        }

        public bool CheckInitFinished()
        {
            if (this.mIsInitBegan == false)
            {
				throw new GeneticAlgorithmInitializationNotStartedException();
            }
            if (this.mDaysCount <= 0)
            {
				throw new GeneticAlgorithmDaysNegativeNumberException();
            }
            if (this.mPeriodsCount <= 0)
            {
				throw new GeneticAlgorithmPeriodsNegativeNumberException();
            }
            if (this.mData == null)
            {
				throw new GeneticAlgorithmDataIsNullException();
            }
            if (this.mData.Count == 0)
            {
				throw new GeneticAlgorithmDataIsEmptyException();
            }
			if (this.mSubjectsDifficulty == null)
			{
				throw new GeneticAlgorithmDifficultyPatternIsNullException();
			}
            return true;
        }

        private bool IsThereAScheduleOkWithConstraints()
        {
			if (this.mGenerationCycles > 2)
			{
				if (this.mLastSuiting.Rating.Errors == this.mCurrentGeneration[0].Rating.Errors)
				{
					this.SameRatingCount++;
				}
				else
				{
					this.SameRatingCount = 1;
				}
			}
			this.mLastSuiting = this.mCurrentGeneration[0];
			this.mSuitingConstraints = this.mCurrentGeneration[0];
			this.mSuitingConstraints.CalculateRating();
            if (this.mCurrentGeneration[0].Rating.Errors > -3)
            {
                return true;
            }
            return false;
        }

        private void MakeNewGeneration(int mutationsCount)
        {
            Random rnd = new Random();
            /*
			foreach (var item in mCurrentGeneration)
			{
				mNextGeneration.Add(item);
			}*/
			for (int f = 0; f < this.mCurrentGeneration.Count; ++f)
			{
				for (int s = 0; s < this.mCurrentGeneration.Count; ++s)
				{
					if (f != s)
					{
						s1 = new Schedule(this.mCurrentGeneration[f], this.mCurrentGeneration[s], SubjectsDifficulty);
						double randomNumber = rnd.NextDouble();
						if (randomNumber < MutationPercentage)
						{
							s1.Mutate(mutationsCount);
						}
						/*if (s1.Not(this.compDict))
						{
							s1 = new Schedule(SaveCopy.Timetable, mSubjectsDifficulty);
							s1.Shuffle(rnd);
						}*/
						mNextGeneration[f * this.mCurrentGeneration.Count + s] = s1;
						
					}
					else
					{
						mNextGeneration[f * mCurrentGeneration.Count + s] = mCurrentGeneration[f];
					}
				}
			}
            //mNextGeneration[rnd.Next(mNextGeneration.Count)].Mutate(Days * PeriodsCount);
			//EqualityComparer<Schedule> comp = new ScheduleComparator(false);
            this.mCurrentGeneration = mNextGeneration.
            OrderByDescending(x => {
				return x.Rating.Errors ;
			}).
            /*Distinct(comp).*/ToList().GetRange(0, GenerationSize);
            // my generation, babyy :D
        }

        public void Generate()
        {
            if (this.mIsInitialized == false)
            {
                throw new GeneticAlgorithmNotInitializedException("Initialization not completed");
            }
			compDict = new Dictionary<Tuple<Class, Subject, List<Group>>, int>();
			for (int day = 0; day < SaveCopy.Timetable.Count; ++day)
			{
				for (int classN = 0; classN < SaveCopy.Timetable[day].Classes.Count; ++classN)
				{
					for (int lesson = 0; lesson < SaveCopy.Timetable[day].Classes[classN].Lessons.Count; ++lesson)
					{
						Lesson l = SaveCopy.Timetable[day].Classes[classN].Lessons[lesson];
						if (l != null)
						{
							Tuple<Class, Subject, List<Group>> t = new Tuple<Class, Subject, List<Group>>(l.Class, l.Subject, l.Groups);
							if (compDict.ContainsKey(t))
							{
								compDict[t]++;
							}
							else
							{
								compDict.Add(t, 1);
							}
						}
					}
				}
			}
			this.mNextGeneration = new List<Schedule>();
			for (int i = 0; i < GenerationSize * GenerationSize; ++i) mNextGeneration.Add(null);
			Random rnd = new Random();
            while (!IsThereAScheduleOkWithConstraints())
            {
				this.mLastSuiting = this.mCurrentGeneration[0];
                int timeBeforeStartingTheNewGeneration = DateTime.Now.Millisecond + (DateTime.Now.Second * 1000);
                MakeNewGeneration(MutationsCount);
                this.Time = (DateTime.Now.Second * 1000 + DateTime.Now.Millisecond) - timeBeforeStartingTheNewGeneration;
                mGenerationCycles++;
				//this.mCurrentGeneration[GenerationSize - 1].Shuffle(rnd);
				if (this.SameRatingCount > 30)
				{
					for (int i = 0; i < this.mCurrentGeneration.Count; i++)
					{
						this.mCurrentGeneration[i].Mutate(MutationsCount);
					}
				}
            }
			this.mFinished = true;
        }
        
        #endregion

        #region Properties

        public int GenerationCycles
        {
            get
            {
                return this.mGenerationCycles;
            }
        }

        public int PeriodsCount
        {
            get
            {
                return this.mPeriodsCount;
            }
            set
            {
                if (value < 0)
                {
                    throw new GeneticAlgorithmException("Number if the periods cannot be negative.");
                }
                this.mPeriodsCount = value;
            }
        }

        public int Days
        {
            get
            {
                return this.mDaysCount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new GeneticAlgorithmException("Non-positive number passed for Days property");
                }
                this.mDaysCount = value;
            }
        }

		public AlgorithmParameters SubjectsDifficulty
		{
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("null given for SubjectsDifficulty property");
				}
				this.mSubjectsDifficulty = value;
			}
			get
			{
				return this.mSubjectsDifficulty;
			}
		}

        public List<Curriculum> Data
        {
            get
            {
                return this.mData;
            }
            set
            {
                if (value == null)
                {
                    throw new GeneticAlgorithmException("null passed for Data property");
                }
                if (value.Count == 0)
                {
                    throw new GeneticAlgorithmException("Empty list passed for Data property");
                }
                this.mData = value;
            }
        }

        public Schedule Generated
        {
            get
            {
                return this.mSuitingConstraints;
            }
        }

		public bool Finished
		{
			get
			{
				return this.mFinished;
			}
		}
        #endregion

        public int Time;
    }
}
