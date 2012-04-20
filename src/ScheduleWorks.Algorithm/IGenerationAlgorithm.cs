using System.Collections.Generic;
using ScheduleWorks.Utility;

namespace ScheduleWorks.Algorithm
{
    interface IGenerationAlgorithm
    {
        void BeginInit();
        bool CheckInitFinished();
        void EndInit();
        void Generate();
		int PeriodsCount
		{
			get;
			set;
		}
		int Days
		{
			get;
			set;
		}
		Schedule Generated
		{
			get;
		}
		List<Curriculum> Data
		{
			set;
			get;
		}
		AlgorithmParameters SubjectsDifficulty
		{
			get;
			set;
		}
    }
}
