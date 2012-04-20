using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScheduleWorks.UI
{
    public partial class HomeScreenForm : Telerik.WinControls.UI.ShapedForm
    {
        public HomeScreenForm()
        {
            InitializeComponent();

            radWaitingBar1.StartWaiting();
        }
    }
}
