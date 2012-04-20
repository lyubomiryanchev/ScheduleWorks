using System;
//using System.Threading;
using System.Timers;
using System.Collections.Generic;
using ScheduleWorks.Algorithm;
using ScheduleWorks.DBImport;
using ScheduleWorks.UI;
using ScheduleWorks.Utility;
using Telerik.WinControls.UI;
using Telerik.Data;

namespace ScheduleWorks.Core
{
	class ScheduleWorks
	{
		public static ScheduleWorks MainProg;
		public System.Threading.Thread algoThr;
		public MalvinaAlgorithm ga;
		private DBManager dbManager;
		private MainFormProgram Interface;
        [STAThread]
        public static void Main()
        {
			MainProg = new ScheduleWorks();
			MainProg.dbManager = new DBManager();
			MainProg.Interface = new MainFormProgram(MainProg.dbManager);
			MainProg.Interface.MainForm.AlgorithmStart += new AlgorithmStartHandler(MainProg.RunAlgorithm);
			MainProg.Interface.MainForm.AlgorithmStop += new AlgorithmStopHandler(MainProg.StopAlgorithm);
			MainProg.Interface.MainForm.AlgorithmCheckFinished += new AlgorithmCheckFinishedHandler(MainProg.CheckFinished);
			MainProg.Interface.MainForm.AlgorithmGetGenerated += new AlgorithmGetGeneratedScheduleHandler(MainProg.GetGenerated);
			MainProg.Interface.RunForm();
        }
			
		public void RunAlgorithm(DBManager db, int days, int MaximumHours, AlgorithmParameters Params)
		{
			this.ga = new MalvinaAlgorithm();
			ga.BeginInit();
			ga.Days = days;
			ga.PeriodsCount = MaximumHours;
			List<Curriculum> data = db.Lessons;
			ga.Data = data;
			ga.SubjectsDifficulty = Params;
			try
			{
				ga.EndInit();
			}
			catch (GeneticAlgorithmNotInitializedException e)
			{
				if (e.InnerException is GeneticAlgorithmDataIsEmptyException)
				{
					this.Interface.MainForm.SendMessage("Моля, въведете уроци.");	
				}
				else if (e.InnerException is GeneticAlgorithmDataIsNullException)
				{
					this.Interface.MainForm.SendMessage("");
				}
				else if (e.InnerException is GeneticAlgorithmDaysNegativeNumberException)
				{
					this.Interface.MainForm.SendMessage("");
				}
				else if (e.InnerException is GeneticAlgorithmDifficultyPatternIsNullException)
				{
					this.Interface.MainForm.SendMessage("");
				}
				else if (e.InnerException is GeneticAlgorithmPeriodsNegativeNumberException)
				{
					this.Interface.MainForm.SendMessage("");
				}
			}
			algoThr = new System.Threading.Thread(delegate()
			{
				ga.Generate();
				ReportGenerationAlgorithmFinished();
			});
			algoThr.Start();
		}

		public void StopAlgorithm()
		{
			algoThr.Abort();
			algoThr = null;
		}

		public bool CheckFinished()
		{
			return ga.Finished;	
		}

		public void ReportGenerationAlgorithmFinished()
		{
			this.Interface.MainForm.AlgorithmFinished();
		}
		public List<Day> GetGenerated()
		{
			if (ga.Finished)
			{
				return ga.Generated.Timetable;
			}
			else
			{
				return new List<Day>();
			}
		}
	}
}
