using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ScheduleWorks.Utility;

namespace ScheduleWorks.UI
{
    public partial class EditGroupsForm : Telerik.WinControls.UI.RadForm
    {
        DBManager mDBManager;
        Class mClass;

        public EditGroupsForm(DBManager aDBManager, int classID)
        {
            InitializeComponent();

            mDBManager = aDBManager;
            mClass = mDBManager.Classes[0];
            foreach(var c in mDBManager.Classes){
                if(c.ID == classID){
                    mClass = c;
                    break;
                }
            }

            gridviewGroups.Columns.Add("Име");
            gridviewGroups.AllowAutoSizeColumns = true;
            gridviewGroups.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridviewGroups.AllowDrop = false;
            gridviewGroups.AllowMultiColumnSorting = false;
            gridviewGroups.AllowDragToGroup = false;
            gridviewGroups.ShowGroupPanel = false;

            try
            {
                foreach (var group in mClass.Groups)
                {
                    gridviewGroups.Rows.Add(group);
                }
            }
            catch {
                mClass.Groups = new List<string>();
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            try
            {
                mClass.Groups.Clear();
            }
            catch { };
            foreach (var r in gridviewGroups.Rows)
            {
                mClass.Groups.Add(r.Cells[0].Value.ToString());
            }
            this.Close();
        }
    }
}
