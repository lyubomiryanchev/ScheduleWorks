using System;
using System.Collections.Generic;
using ScheduleWorks.Utility;
using System.Linq;

namespace ScheduleWorks.Algorithm
{
    public class Schedule
    {
        private List<Day> mDays;
        private Rating mRating;

        public Schedule()
        {
            this.mDays = new List<Day>{ };
        }

        public Schedule(List<Day> timetable)
        {
			SetTimetable(timetable);
        }

		public Schedule(List<Day> timetable, AlgorithmParameters parameters)
		{
			this.DifficultyPattern = parameters;
			SetTimetable(timetable);
		}

        public Schedule(Schedule firstParent, Schedule secondParent, AlgorithmParameters parameters)
        : this()
        {
			this.DifficultyPattern = parameters;
            if (firstParent.Timetable.Count != secondParent.Timetable.Count)
            {
                throw new GeneticAlgorithmException("Passed pair of parents with different count of days");
			}

			#region Lessons combination

			List<Day> d = new List<Day>{};
            Dictionary<Tuple<Lesson, Parent>, List<Index>> dict = new Dictionary<Tuple<Lesson, Parent>, List<Index>>{ };
			Dictionary<Index, List<Tuple<Lesson, Parent>>> indexesDict = new Dictionary<Index,List<Tuple<Lesson,Parent>>>();
            for (int day = 0; day < firstParent.Timetable.Count; ++day)
            {
                if (firstParent.Timetable[day].Classes.Count != secondParent.Timetable[day].Classes.Count)
                {
                    throw new GeneticAlgorithmException("Passed pair of parents with different classes for a given day");
                }
                List<ClassSchedule> schedules = new List<ClassSchedule>{ };
                for (int classN = 0; classN < firstParent.Timetable[day].Classes.Count; ++classN)
                {
                    List<Lesson> lessons = new List<Lesson>{ };
                    for (int lesson = 0; lesson < Math.Max(firstParent.Timetable[day].Classes[classN].Lessons.Count,
                                                           secondParent.Timetable[day].Classes[classN].Lessons.Count); ++lesson)
                    {
						bool should = false;
                        /*if (firstParent.Timetable[day].Classes[classN].Lessons[lesson].Equals(secondParent.Timetable[day].Classes[classN].Lessons[lesson]))
                        {
                            lessons.Add(firstParent.Timetable[day].Classes[classN].Lessons[lesson]);
						}
                        else
                        {
                            lessons.Add(null);
							
						}*/
						if (firstParent.Timetable[day].Classes[classN].Lessons[lesson] == null && secondParent.Timetable[day].Classes[classN].Lessons[lesson] == null)
						{
							lessons.Add(null);
						}
						else
						{
							if (firstParent.Timetable[day].Classes[classN].Lessons[lesson] != null &&
								secondParent.Timetable[day].Classes[classN].Lessons[lesson] != null)
							{
								if (firstParent.Timetable[day].Classes[classN].Lessons[lesson].Equals(secondParent.Timetable[day].Classes[classN].Lessons[lesson]))
								{
									lessons.Add(secondParent.Timetable[day].Classes[classN].Lessons[lesson]);
								}
								else
								{
									should = true;
									lessons.Add(null);
								}
							}
							else
							{
								should = true;
								lessons.Add(null);
							}
						}
						if (should)
						{
							#region dictionary
							Index shit = new Index(day, classN, lesson);
							Tuple<Lesson, Parent> t =
								new Tuple<Lesson, Parent>(firstParent.Timetable[day].Classes[classN].Lessons[lesson], Parent.FirstParent);
							indexesDict.Add(shit, new List<Tuple<Lesson,Parent>>{ t });
							if (dict.ContainsKey(t)) dict[t].Add(shit);
							else dict.Add(t, new List<Index> { shit });
							t = new Tuple<Lesson, Parent>(secondParent.Timetable[day].Classes[classN].Lessons[lesson], Parent.SecondParent);
							indexesDict[shit].Add(t);
							if (dict.ContainsKey(t)) dict[t].Add(shit);
							else dict.Add(t, new List<Index> { shit });
							#endregion
						}
                    }
                    ClassSchedule cs = new ClassSchedule(firstParent.Timetable[day].Classes[classN].Class, lessons);
                    schedules.Add(cs);
                }
                Day current = new Day(schedules);
                d.Add(current);
            }
			this.mDays = d;
            Tuple<Lesson, Parent>[] a = new Tuple<Lesson,Parent>[dict.Keys.Count];
            dict.Keys.CopyTo(a, 0);
            int rand;
            Random rnd = new Random();
			#region Old resolving
			/*
			int left = dict.Count;
			while (dict.Count != 0 && left > 0)
            {
                rand = rnd.Next(left);
                Tuple<Lesson, Parent> t = a[rand];
                if (!dict.ContainsKey(t))
                {
                    goto end;
                }
                List<Index> li = dict[t];
                Index inx = li[li.Count - 1];
                li.RemoveAt(li.Count - 1);
                if (li.Count == 0)
                {
                    if (t.Item2 == Parent.FirstParent)
                    {
                        dict.Remove(new Tuple<Lesson,Parent>(t.Item1, Parent.SecondParent));
                    }
                    else
                    {
                        dict.Remove(new Tuple<Lesson,Parent>(t.Item1, Parent.FirstParent));
                    }
                    dict.Remove(t);
                }
                if (t.Item2 == Parent.FirstParent)
                {
                    d[inx.Day].Classes[inx.ClassN].Lessons[inx.Period] = firstParent.Timetable[inx.Day].Classes[inx.ClassN].Lessons[inx.Period];
                }
                else
                {
                    d[inx.Day].Classes[inx.ClassN].Lessons[inx.Period] = secondParent.Timetable[inx.Day].Classes[inx.ClassN].Lessons[inx.Period];
                }
            end:
                left--;
                Tuple<Lesson, Parent> swap = a[rand];
                a[rand] = a[left];
                a[left] = swap;
			}*/
			#endregion
			int ConflictsCount = 0;
			#region New Resolving - up-to-date at 21 March of 2011
			foreach (var item in dict)
			{
				ConflictsCount += item.Value.Count;
			}
			ConflictsCount /= 2;
			int ConflictsResolved = 0;
			try
			{
				while (ConflictsResolved < ConflictsCount)
				{
					#region build indexesDict
					indexesDict = new Dictionary<Index, List<Tuple<Lesson, Parent>>>();
					for (int day = 0; day < firstParent.Timetable.Count; ++day)
					{
						if (firstParent.Timetable[day].Classes.Count != secondParent.Timetable[day].Classes.Count)
						{
							throw new GeneticAlgorithmException("Passed pair of parents with different classes for a given day");
						}
						for (int classN = 0; classN < firstParent.Timetable[day].Classes.Count; ++classN)
						{
							for (int lesson = 0; lesson < Math.Max(firstParent.Timetable[day].Classes[classN].Lessons.Count,
																   secondParent.Timetable[day].Classes[classN].Lessons.Count); ++lesson)
							{
								bool should = false;
								if (firstParent.Timetable[day].Classes[classN].Lessons[lesson] == null && secondParent.Timetable[day].Classes[classN].Lessons[lesson] == null)
								{
									should = false;
								}
								else
								{
									if (firstParent.Timetable[day].Classes[classN].Lessons[lesson] != null &&
										secondParent.Timetable[day].Classes[classN].Lessons[lesson] != null)
									{
										if (firstParent.Timetable[day].Classes[classN].Lessons[lesson].Equals(secondParent.Timetable[day].Classes[classN].Lessons[lesson]))
										{
											should = false;
										}
										else
										{
											should = true;
										}
									}
									else
									{
										should = true;
									}
								}
								if (this.Timetable[day].Classes[classN].Lessons[lesson] != null)
									if (should)
									{
										#region dictionary
										Index shit = new Index(day, classN, lesson);
										Tuple<Lesson, Parent> t =
											new Tuple<Lesson, Parent>(firstParent.Timetable[day].Classes[classN].Lessons[lesson], Parent.FirstParent);
										indexesDict.Add(shit, new List<Tuple<Lesson, Parent>> { t });
										t = new Tuple<Lesson, Parent>(secondParent.Timetable[day].Classes[classN].Lessons[lesson], Parent.SecondParent);
										indexesDict[shit].Add(t);
										#endregion
									}
							}
						}
					}
					#endregion
					if (dict.Count == 0)
					{
						throw new GeneticAlgorithmException();
					}
					dict.Keys.CopyTo(a, 0);
					rand = rnd.Next(dict.Keys.Count);
					var key = a[rand];
					#region Opposite construction
					Parent oppositeParent = Parent.FirstParent;
					if (key.Item2 == Parent.FirstParent)
					{
						oppositeParent = Parent.SecondParent;
					}
					else
					{
						oppositeParent = Parent.FirstParent;
					}
					#endregion
					var oppositeKey = new Tuple<Lesson, Parent>(key.Item1, oppositeParent);
					Index ind = dict[key][dict[key].Count - 1];
					if (dict.ContainsKey(oppositeKey))
					{
						Index oppositeIndex = dict[oppositeKey][dict[oppositeKey].Count - 1];
						this.Timetable[ind.Day].Classes[ind.ClassN].Lessons[ind.Period] = key.Item1;
						#region Dictionary update

						var found = indexesDict[ind];
						Tuple<Lesson, Parent> keyToChange;
						if (found[0].Item2 != key.Item2)
						{
							keyToChange = found[0];
						}
						else
						{
							keyToChange = found[1];
						}
						var swap = indexesDict[ind][(int)oppositeParent];
						indexesDict[oppositeIndex][(int)oppositeParent] = indexesDict[ind][(int)oppositeParent];
						indexesDict[ind][(int)oppositeParent] = swap;

						for (int i = 0; i < dict[keyToChange].Count; ++i)
						{
							if (dict[keyToChange][i].Equals(ind))
							{
								dict[keyToChange][i] = new Index(ind.Day, ind.ClassN, ind.Period);
							}
						}

						dict[key].RemoveAt(dict[key].Count - 1);
						if (dict[key].Count == 0) dict.Remove(key);
						dict[oppositeKey].RemoveAt(dict[oppositeKey].Count - 1);
						if (dict[oppositeKey].Count == 0) dict.Remove(oppositeKey);

						ConflictsResolved++;
						#endregion
					}
					else throw new GeneticAlgorithmException();
				}
			}
			catch (KeyNotFoundException e)
			{
				goto end;
			}
			if (dict.Count != 0)
			{
				throw new Exception();
			}

			#endregion

			#endregion

			#region Classrooms switching

			Dictionary<Classroom, bool> classrooms = new Dictionary<Classroom, bool>();

			for (int day = 0; day < d.Count; ++day)
			{
				for (int lesson = 0; lesson < d[day].Classes[0].Lessons.Count; ++lesson)
				{
					classrooms.Clear();
					for (int classN = 0; classN < d[day].Classes.Count; ++classN)
					{
						Lesson l = d[day].Classes[classN].Lessons[lesson];
						if (l == null) continue;
						foreach (Group g in l.Groups)
						{
							if (g.Room != null)
							{
								if (classrooms.ContainsKey(g.Room))
								{
									bool broken = false;
									for (int i = 0; i < g.AlternativeRooms.Count; ++i)
									{
										if (!classrooms.ContainsKey(g.AlternativeRooms[i]))
										{
											g.Room = g.AlternativeRooms[i];
											classrooms.Add(g.Room, true);
											broken = true;
											break;
										}
									}
									if (!broken)
									{
										g.Room = g.DesiredRoom;
									}
								}
								else
								{
									classrooms.Add(g.Room, true);
								}
							}
						}
					}
				}
			}

			#endregion
			end:
			this.mDays = d;
            this.mRating = CalculateRating();
        }

		private void SetTimetable(List<Day> timetable)
		{
			this.mDays = new List<Day>();
			for (int day = 0; day < timetable.Count; ++day)
			{
				List<ClassSchedule> Lcs = new List<ClassSchedule>();
				for (int classN = 0; classN < timetable[day].Classes.Count; ++classN)
				{
					List<Lesson> lessons = new List<Lesson>();
					for (int lesson = 0; lesson < timetable[day].Classes[classN].Lessons.Count; ++lesson)
					{
						lessons.Add(timetable[day].Classes[classN].Lessons[lesson]);
					}
					ClassSchedule cs = new ClassSchedule(timetable[day].Classes[classN].Class, lessons);
					Lcs.Add(cs);
				}
				Day d = new Day(Lcs);
				this.mDays.Add(d);
			}
			this.mRating = CalculateRating();
		}

        /// <summary>
        /// Calculates the rating of the current schedule
        /// </summary>
        /// <returns>Rating element - two properties: Rating.Errors, Rating.RequiermentsFulfil  </returns>
        public Rating CalculateRating()
        {
            Rating answer = new Rating();
            Dictionary<Teacher, int> dict = new Dictionary<Teacher, int>();
			bool started;
			int lastNull;

			#region Errors calculation

			#region Teachers errors

			for (int day = 0; day < this.mDays.Count; ++day)
            {
                for (int lesson = 0; lesson < this.mDays[day].Classes[0].Lessons.Count; ++lesson)
                {
                    dict.Clear();
					
                    for (int classN = 0; classN < this.mDays[day].Classes.Count; ++classN)
                    {
						if (this.mDays[day].Classes[classN].Lessons[lesson] != null)
						{
							foreach (var item in this.mDays[day].Classes[classN].Lessons[lesson].Groups)
							{
								if (item.Teacher != null)
								{
									if (dict.ContainsKey(item.Teacher))
									{
										dict[item.Teacher]++;
									}
									else
									{
										dict.Add(item.Teacher, 1);
									}
								}
							}
						}
                    }
					
					//Console.WriteLine("-- {0}", dict.Count);
                    foreach (var item in dict)
                    {
                        answer.Errors -= (item.Value - 1) * (item.Value - 1);
                    }
                }
			}
			#endregion

			#region Free hours

			for (int day = 0; day < this.mDays.Count; ++day)
			{
				for (int classN = 0; classN < this.mDays[day].Classes.Count; ++classN)
				{
					started = false;
					lastNull = 0;
					if (mDays[day].Classes[classN].Lessons[0] == null) answer.Errors -= 1;
					for (int lesson = 0; lesson < this.mDays[day].Classes[0].Lessons.Count; ++lesson)
					{
						if (this.mDays[day].Classes[classN].Lessons[lesson] != null)
						{
							started = true;
							lastNull = 0;
						}
						else
						{
							if (started)
							{
								answer.Errors -= 5;
								lastNull++;
							}
						}
					}
					answer.Errors += lastNull * 5;
				}
			}

			#endregion

			#region Classroom

			Dictionary<Classroom, int> classrooms = new Dictionary<Classroom, int>();

			for (int day = 0; day < this.mDays.Count; ++day)
			{
				for (int lesson = 0; lesson < this.mDays[day].Classes[0].Lessons.Count; ++lesson)
				{
					classrooms.Clear();

					for (int classN = 0; classN < this.mDays[day].Classes.Count; ++classN)
					{
						if (this.mDays[day].Classes[classN].Lessons[lesson] != null)
						{
							foreach (var item in this.mDays[day].Classes[classN].Lessons[lesson].Groups)
							{
								if (item.Room != null)
								{
									if (classrooms.ContainsKey(item.Room))
									{
										classrooms[item.Room]++;
									}
									else
									{
										classrooms.Add(item.Room, 1);
									}
								}
							}
						}
					}

					//Console.WriteLine("-- {0}", dict.Count);
					foreach (var item in classrooms)
					{
						answer.Errors -= (item.Value - 1) * (item.Value - 1);
					}
				}
			}

			#endregion
			#endregion

			#region Preferences calculation

			#region Difficulty pattern

			int CountLessons = 0;
			int MatchingPattern = 0;
			int CurrentDayLessonsCount;
			int CurrentDayLesson;

			foreach (var day in mDays)
			{
				foreach (var classN in day.Classes)
				{
					CurrentDayLessonsCount = 0;
					CurrentDayLesson = 0;
					if (classN.Lessons[0] == null)
					{
						answer.Errors -= 1;
					}
					for (int i = 0; i < classN.Lessons.Count; i++)
					{
						if (classN.Lessons[i] != null)
						{
							CurrentDayLessonsCount++;
						}
					}
					foreach (var lesson in classN.Lessons)
					{
						if (lesson != null)
						{
							//if (CurrentDayLessonsCount < 4) answer.Errors -= 1;
							switch (CurrentDayLessonsCount)
							{
								case 4:
									if ((DifficultyPattern.FourHoursPerDay[CurrentDayLesson] & lesson.Subject.Difficulty) == lesson.Subject.Difficulty)
										MatchingPattern++;
									break;
								case 5:
									if ((DifficultyPattern.FiveHoursPerDay[CurrentDayLesson] & lesson.Subject.Difficulty) == lesson.Subject.Difficulty)
										MatchingPattern++;
									break;
								case 6:
									if ((DifficultyPattern.SixHoursPerDay[CurrentDayLesson] & lesson.Subject.Difficulty) == lesson.Subject.Difficulty)
										MatchingPattern++;
									break;
								case 7:
									if ((DifficultyPattern.SevenHoursPerDay[CurrentDayLesson] & lesson.Subject.Difficulty) == lesson.Subject.Difficulty)
										MatchingPattern++;
									break;
								default:
									break;
							}
							CountLessons++;
							CurrentDayLesson++;
						}
					}
				}
			}

			if (CountLessons > 0) 
				answer.DifficultyPatternMatching += (1 << 10) * MatchingPattern / CountLessons;
			
			#endregion

			#region Teachers pattern



			#endregion

			#endregion

			return answer;
        }

        public void Mutate(int mutationCount)
        {
            /*
             * Possibly I can implement mutation adopted to remove errors
             */
            /*
            Dictionary<Teacher, List<Index>> dict = new Dictionary<Teacher, List<Index>>();
            for (int day = 0; day < this.mDays.Count; ++day)
            {
                for (int lesson = 0; lesson < this.mDays[day].Classes[0].Lessons.Count; ++lesson)
                {
                    dict.Clear();
                    for (int classN = 0; classN < this.mDays[day].Classes.Count; ++classN)
                    {
                        if (this.mDays[day].Classes[classN].Lessons[lesson] != null)
                        {
                            if (dict.ContainsKey(this.mDays[day].Classes[classN].Lessons[lesson].Teacher))
                            {
                                dict[this.mDays[day].Classes[classN].Lessons[lesson].Teacher].Add(new Index(day, classN, lesson));
                            }
                            else
                            {
                                dict.Add(this.mDays[day].Classes[classN].Lessons[lesson].Teacher, new List<Index>(){new Index(day, classN, lesson)});
                            }
                        }
                    }
                }
            }
            */
            for (int i = 0; i < mutationCount; ++i)
            {
                Random rnd = new Random();
                int classN = rnd.Next(this.mDays[0].Classes.Count);
                int firstDay = rnd.Next(this.mDays.Count);
                int secondDay = rnd.Next(this.mDays.Count);
                int firstLesson = rnd.Next(this.mDays[firstDay].Classes[classN].Lessons.Count);
                int secondLesson = rnd.Next(this.mDays[secondDay].Classes[classN].Lessons.Count);
                Lesson swap;
                swap = mDays[firstDay].Classes[classN].Lessons[firstLesson];
                mDays[firstDay].Classes[classN].Lessons[firstLesson] = mDays[secondDay].Classes[classN].Lessons[secondLesson];
                mDays[secondDay].Classes[classN].Lessons[secondLesson] = swap;
            }
			this.mRating = CalculateRating();
        }

        public void Shuffle(Random rnd)
        {
            int dayr;
            int classNr;
            int lessonr;
            for (int day = 0; day < this.mDays.Count; ++day)
            {
                for (int classN = 0; classN < this.mDays[day].Classes.Count; ++classN)
                {
                    for (int lesson = 0; lesson < this.mDays[day].Classes[classN].Lessons.Count; ++lesson)
                    {
                        dayr = rnd.Next(this.mDays.Count);
                        //classNr = rnd.Next(this.mDays[dayr].Classes.Count);
						classNr = classN;
                        lessonr = rnd.Next(this.mDays[dayr].Classes[classNr].Lessons.Count);
                        Lesson swap = this.mDays[day].Classes[classN].Lessons[lesson];
                        this.mDays[day].Classes[classN].Lessons[lesson] = this.mDays[dayr].Classes[classNr].Lessons[lessonr];
                        this.mDays[dayr].Classes[classNr].Lessons[lessonr] = swap;
                    }
                }
            }
			this.mRating = CalculateRating();
        }

		public bool Not(Dictionary<Tuple<Class, Subject, List<Group>>, int> compDict)
		{
			//= new Dictionary<Tuple<Class, Subject, List<Group>>, int>();
			Dictionary<Tuple<Class, Subject, List<Group>>, int> thisDict = new Dictionary<Tuple<Class, Subject, List<Group>>, int>();

			for (int day = 0; day < this.Timetable.Count; ++day)
			{
				for (int classN = 0; classN < this.Timetable[day].Classes.Count; ++classN)
				{
					for (int lesson = 0; lesson < this.Timetable[day].Classes[classN].Lessons.Count; ++lesson)
					{
						Lesson l = this.Timetable[day].Classes[classN].Lessons[lesson];
						if (l != null)
						{
							Tuple<Class, Subject, List<Group>> t = new Tuple<Class, Subject, List<Group>>(l.Class, l.Subject, l.Groups);
							if (thisDict.ContainsKey(t))
							{
								thisDict[t]++;
							}
							else
							{
								thisDict.Add(t, 1);
							}
						}
					}
				}
			}
			try
			{
				foreach (var pair in compDict)
				{
					if (pair.Value != thisDict[pair.Key])
						return true;
				}
			}
			catch (KeyNotFoundException e)
			{
				return true;
			}
			return false;
		}

        public List<Day> Timetable
        {
            get
            {
                return this.mDays;
            }
        }

        public Rating Rating
        {
            get
            {
                return this.mRating;
            }
        }

		public AlgorithmParameters DifficultyPattern
		{
			get;
			set;
		}
    }
}
