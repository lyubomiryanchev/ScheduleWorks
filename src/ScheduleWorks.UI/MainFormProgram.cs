using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.Primitives;
using ScheduleWorks.Utility;

namespace ScheduleWorks.UI
{
    public class MainFormProgram
    {
		public MainForm MainForm;
        private UI.HomeScreenForm homeForm;
        System.Threading.Thread homeThr;

		public MainFormProgram(DBManager dbManager)
		{
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            homeThr = new System.Threading.Thread(delegate()
            {
                homeForm = new HomeScreenForm();
                Application.Run(homeForm);
            });
            homeThr.Start();
            //Application.Run(homeForm);
			MainForm = new UI.MainForm(dbManager);
			GC.KeepAlive(MainForm);
		}

		[STAThread]
        public void RunForm()
        {
            homeThr.Abort();
            Application.Run(MainForm);
        }
    }
}
