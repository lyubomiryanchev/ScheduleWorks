using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ScheduleWorks.UI.Properties;
using Telerik.WinControls.UI;
using ScheduleWorks.Utility;

namespace ScheduleWorks.UI
{
    public partial class SetTimeoffForm : Telerik.WinControls.UI.RadForm
    {
        Image okayImage = Resources.acceptImage;
        Image notOkayImage = Resources.deleteImage;
        Image notSureImage = Resources.helpImage;

        TimeOffEnum[,] timeoff = new TimeOffEnum[Consts.TimeOffEnumSizeX, Consts.TimeOffEnumSizeY];

        DBManager mDBManager;

        public SetTimeoffForm(DBManager aDBManager, ObjectType type, long ID)
        {
            InitializeComponent();

            TimeOffEnum[,] time = new TimeOffEnum[Consts.TimeOffEnumSizeX, Consts.TimeOffEnumSizeY];

            mDBManager = aDBManager;

            switch (type)
            {
                case ObjectType.Class:
                    foreach (var c in aDBManager.Classes)
                    {
                        if (c.ID == ID)
                        {
                            time = c.Timeoff;
                            break;
                        }
                    }
                break;

                case ObjectType.Subject:
                    foreach (var c in aDBManager.Subjects)
                    {
                        if (c.ID == ID)
                        {
                            time = c.Timeoff;
                            break;
                        }
                    }
                break;

                case ObjectType.Classroom:
                foreach (var c in aDBManager.Classrooms)
                {
                    if (c.ID == ID)
                    {
                        time = c.Timeoff;
                        break;
                    }
                }
                break;

                case ObjectType.Teacher:
                foreach (var c in aDBManager.Teachers)
                {
                    if (c.ID == ID)
                    {
                        time = c.Timeoff;
                        break;
                    }
                }
                break;

                case ObjectType.Lesson:
                foreach (var c in aDBManager.Lessons)
                {
                    if (c.ID == ID)
                    {
                        time = c.Timeoff;
                        break;
                    }
                }
                break;
            }

            timeoff = time;

            this.Text = "Време за почивка";

            gridviewTimeoff.AllowAddNewRow = false;
            gridviewTimeoff.AllowEditRow = false;
            gridviewTimeoff.AllowDeleteRow = false;
            gridviewTimeoff.AllowDragToGroup = false;
            gridviewTimeoff.AllowRowReorder = false;
            gridviewTimeoff.AllowRowResize = false;
            gridviewTimeoff.AllowColumnResize = false;
            gridviewTimeoff.EnableSorting = false;
            gridviewTimeoff.ShowGroupPanel = false;
            gridviewTimeoff.ShowRowHeaderColumn = false;

            gridviewTimeoff.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            gridviewTimeoff.Columns["number"].TextAlignment = ContentAlignment.MiddleCenter;

            for (int i = 0; i < 7; i++)
            {
                Image[] images = new Image[5];

                int counter = 0;
                foreach (Image im in images)
                {
                    switch (time[counter, i])
                    {
                        case TimeOffEnum.Yes:
                            images[counter] = okayImage;
                            break;
                        case TimeOffEnum.No:
                            images[counter] = notOkayImage;
                            break;
                        case TimeOffEnum.NotSure:
                            images[counter] = notSureImage;
                            break;
                    }
                    counter++;
                }

                gridviewTimeoff.Rows.Add(i + 1, images[0], images[1], images[2], images[3], images[4]);
                gridviewTimeoff.Rows[i].Height = 40;
            }
        }

        private void gridviewTimeoff_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column != gridviewTimeoff.Columns["number"] && e.RowIndex != -1)
            {
                switch (timeoff[e.ColumnIndex - 1, e.RowIndex])
                {
                    case TimeOffEnum.Yes:
                        e.Row.Cells[e.ColumnIndex].Value = Resources.deleteImage;
                        timeoff[e.ColumnIndex - 1, e.RowIndex] = TimeOffEnum.No;
                        break;
                    case TimeOffEnum.No:
                        e.Row.Cells[e.ColumnIndex].Value = Resources.helpImage;
                        timeoff[e.ColumnIndex - 1, e.RowIndex] = TimeOffEnum.NotSure;
                        break;
                    case TimeOffEnum.NotSure:
                        e.Row.Cells[e.ColumnIndex].Value = Resources.acceptImage;
                        timeoff[e.ColumnIndex - 1, e.RowIndex] = TimeOffEnum.Yes;
                        break;
                }
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
