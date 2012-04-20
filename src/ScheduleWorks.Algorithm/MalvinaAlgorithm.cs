using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ScheduleWorks.Utility;

namespace ScheduleWorks.Algorithm
{
	class Edge {
		public int neigIndex;
		public int capacity;
		public int backwardsIndex;
		public int backwardsNode;
		public Edge() { }
		public Edge(int neigI, int cap)
		{
			neigIndex = neigI;
			capacity = cap;
		}
	}
	class CHPair
	{
		public Classroom classroom;
		public int hour;
		public int index;
	}
	class CurricLPair
	{
		public Curriculum curric;
		public Lesson lesson;
	}
	public class MalvinaAlgorithm : ScheduleWorks.Algorithm.IGenerationAlgorithm
	{
		#region Members

		private bool mIsInitBegan;
		private bool mIsInitialized;

		private List<Edge>[] neigs;
		private List<Edge> path;
		private int n;
		private int[] bfsNumber;
		private bool[] used;
		private int[,] flowSize;

		private int mPeriodsCount;
		private int mDaysCount;

		private List<Curriculum> mData;

		private List<Classroom> mRooms;

		private AlgorithmParameters mSubjectsDifficulty;

		private Schedule mSuitingConstraints;

		#endregion

		#region Methods

		public void BeginInit()
		{
			this.Finished = false;
			this.mIsInitBegan = true;
			neigs = new List<Edge>[1 << 10];
			path = new List<Edge>();
			bfsNumber = new int[1 << 10];
			used = new bool[1 << 10];
			flowSize = new int[1 << 10, 1 << 10];
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

		private void letFlow()
		{
			int minimal = path[0].capacity;
			for (int i = 0; i < path.Count; ++i)
			{
				if (path[i].capacity < minimal)
					minimal = path[i].capacity;
			}
			for (int i = 0; i < path.Count; ++i)
			{
				path[i].capacity -= minimal;
				neigs[path[i].backwardsNode][path[i].backwardsIndex].capacity += minimal;
				//note for Lyubo: if you ever ever look at this piece of code - don't change it `just to try`
				flowSize[path[i].backwardsNode,
					neigs[path[i].backwardsNode][path[i].backwardsIndex].neigIndex] += minimal;
			}
			//answer += minimal;
		}

		private bool bfs(int source, int sink)
		{
			bfsNumber[sink] = 0;
			Queue<int> que = new Queue<int>();
			que.Enqueue(sink);
			int top;
			int backwardsNode;
			int backwardsIndex;
			while (que.Count > 0)
			{
				top = que.Dequeue();
				if (top == source) { return true; }
				for (int i = 0;i < n; ++i)
				{
					if (bfsNumber[neigs[top][i].neigIndex] == -1)
					{
						backwardsNode = neigs[top][i].backwardsNode;
						backwardsIndex = neigs[top][i].backwardsIndex;
						if (neigs[backwardsNode][backwardsIndex].capacity != 0)
						{
							bfsNumber[neigs[top][i].neigIndex] = bfsNumber[top] + 1;
							que.Enqueue(neigs[top][i].neigIndex);
						}
					}
				}
			}
			return false;
		}
		private bool dfs(int source, int sink)
		{
			if (source == sink)
			{
				letFlow();
				return true;
			}
			bool result = false;
			for (int i = 0;i < neigs[source].Count && !result; ++i)
			{
				if (neigs[source][i].capacity != 0 &&
					!used[neigs[source][i].neigIndex] &&
					bfsNumber[source] - 1 == bfsNumber[neigs[source][i].neigIndex] &&
					bfsNumber[neigs[source][i].neigIndex] != -1)
				{
					path.Add(neigs[source][i]);
					used[neigs[source][i].neigIndex] = true;
					result |= dfs(neigs[source][i].neigIndex, sink);
					path.RemoveAt(path.Count - 1);
				}
			}
			return result;
		}
		public void Generate()
		{
			int source, sink;
			#region Build graph

			List<CHPair> clHourPairs = new List<CHPair>();
			for (int i = 0; i < this.mPeriodsCount * Days; ++i)
			{
				for (int j = 0; j < mRooms.Count; ++j)
				{
					CHPair p = new CHPair() { classroom = mRooms[j], hour = i, index = clHourPairs.Count };
					clHourPairs.Add(p);
				}
			}
			List<CurricLPair> lessons = new List<CurricLPair>();
			foreach (Curriculum curriculum in mData)
			{
				for (int i = 0; i < curriculum.HoursPerWeek; i++ )
				{
					Lesson l = new Lesson(curriculum.Class, curriculum.Subject,
						new List<Group> { });
					CurricLPair p = new CurricLPair() { curric = curriculum, lesson = l };
					lessons.Add(p);
				}
			}

			source = lessons.Count + clHourPairs.Count;
			sink = source + 1;
			n = sink + 1;

			for (int i = 0; i < lessons.Count; ++i)
			{
				var desiredRoom = from t in clHourPairs
								  where t.classroom == lessons[i].curric.DesiredClassroom
								  select t;
				foreach (var t in desiredRoom)
				{
					Edge e = new Edge(t.index + lessons.Count, 2000);
					Edge rev = new Edge(i, 0);
					e.backwardsIndex = neigs[t.index + lessons.Count].Count;
					e.backwardsNode = t.index + lessons.Count;
					rev.backwardsIndex = neigs[i].Count;
					rev.backwardsNode = i;
					neigs[t.index + lessons.Count].Add(rev);
					neigs[i].Add(e);
				}
				for (int j = 0; j < lessons[i].curric.AlternativeClassrooms.Count; ++j)
				{
					var alternative = from t in clHourPairs
									  where t.classroom == lessons[i].curric.AlternativeClassrooms[i]
									  select t;
					foreach (var t in alternative)
					{
						Edge e = new Edge(t.index + lessons.Count, 2000 - j - 1);
						Edge rev = new Edge(i, 0);
						e.backwardsIndex = neigs[t.index + lessons.Count].Count;
						e.backwardsNode = t.index + lessons.Count;
						rev.backwardsIndex = neigs[i].Count;
						rev.backwardsNode = i;
						neigs[t.index + lessons.Count].Add(rev);
						neigs[i].Add(e);
					}
				}

				#region From Source
				
				Edge ed = new Edge(i, 2000);
				Edge reve = new Edge(source, 0);
				ed.backwardsIndex = neigs[i].Count;
				ed.backwardsNode = i;
				reve.backwardsIndex = neigs[source].Count;
				reve.backwardsNode = source;
				neigs[source].Add(ed);
				neigs[i].Add(reve);

				#endregion
			}

			#region To Sink

			for (int i = lessons.Count; i < lessons.Count + clHourPairs.Count; ++i)
			{
				Edge ed = new Edge(sink, 2000);
				Edge reve = new Edge(i, 0);
				ed.backwardsIndex = neigs[sink].Count;
				ed.backwardsNode = sink;
				reve.backwardsIndex = neigs[i].Count;
				reve.backwardsNode = source;
				neigs[i].Add(ed);
				neigs[sink].Add(reve);
			}

			#endregion

			#endregion
			

			#region Matching
			source = n;
			sink = n + 1;
			n += 2;
			for (int i = 0; i < n; ++i)
			{
				bfsNumber[i] = -1;
			}
			while (bfs(source, sink))
			{
				for (int i = 0; i < n; ++i) used[i] = false;
				while (dfs(source, sink))
					for (int i = 0; i < n; ++i) used[i] = false;
				for (int i = 0; i < n; ++i)
				{
					bfsNumber[i] = -1;
				}
			}
			#endregion

			#region Building the schedule
			#endregion
		}

		#endregion

		#region Properties

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
				if (this.mIsInitialized) throw new GeneticAlgorithmException("Initialization finished");
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
				if (this.mIsInitialized) throw new GeneticAlgorithmException("Initialization finished");
				this.mDaysCount = value;
			}
		}

		public List<Classroom> Rooms
		{
			get
			{
				return this.mRooms;
			}
			set
			{
				if (value == null)
				{
					throw new GeneticAlgorithmException("Non-positive number passed for Days property");
				}
				if (this.mIsInitialized) throw new GeneticAlgorithmException("Initialization finished");
				this.mRooms = value;
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
				if (this.mIsInitialized) throw new GeneticAlgorithmException("Initialization finished");
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
				if (this.mIsInitialized) throw new GeneticAlgorithmException("Initialization finished");
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
			get;
			private set;
		}

		#endregion

		public int Time;
	}
}
