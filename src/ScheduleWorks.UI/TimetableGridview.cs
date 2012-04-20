using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScheduleWorks.Utility;
using Telerik.WinControls.UI;

namespace ScheduleWorks.UI
{
    public partial class TimetableGridview : UserControl
    {
        DBManager mDBManager;
        
        public TimetableGridview(DBManager aDBManager, int typeOfPreview, long ID)
        {
            InitializeComponent();

            mDBManager = aDBManager;

            #region Layout setting
            gridviewSchedule.Columns.Add("Час");
            gridviewSchedule.Columns["Час"].Width = 10;
            gridviewSchedule.Columns["Час"].TextAlignment = ContentAlignment.MiddleCenter;
            gridviewSchedule.Columns["Час"].WrapText = true;
            gridviewSchedule.Columns.Add("Понеделник");
            gridviewSchedule.Columns["Понеделник"].TextAlignment = ContentAlignment.MiddleCenter;
            gridviewSchedule.Columns["Понеделник"].WrapText = true;
            gridviewSchedule.Columns.Add("Вторник");
            gridviewSchedule.Columns["Вторник"].TextAlignment = ContentAlignment.MiddleCenter;
            gridviewSchedule.Columns["Вторник"].WrapText = true;
            gridviewSchedule.Columns.Add("Сряда");
            gridviewSchedule.Columns["Сряда"].TextAlignment = ContentAlignment.MiddleCenter;
            gridviewSchedule.Columns["Сряда"].WrapText = true;
            gridviewSchedule.Columns.Add("Четвъртък");
            gridviewSchedule.Columns["Четвъртък"].TextAlignment = ContentAlignment.MiddleCenter;
            gridviewSchedule.Columns["Четвъртък"].WrapText = true;
            gridviewSchedule.Columns.Add("Петък");
            gridviewSchedule.Columns["Петък"].TextAlignment = ContentAlignment.MiddleCenter;
            gridviewSchedule.Columns["Петък"].WrapText = true;

            gridviewSchedule.GridViewElement.DrawBorder = true;
            gridviewSchedule.TableElement.DrawBorder = true;

            gridviewSchedule.AllowAddNewRow = false;
            gridviewSchedule.AllowEditRow = true;
            gridviewSchedule.AllowDeleteRow = false;
            gridviewSchedule.AllowDragToGroup = false;
            gridviewSchedule.AllowRowReorder = false;
            gridviewSchedule.AllowRowResize = true;
            gridviewSchedule.EnableSorting = false;
            gridviewSchedule.ShowGroupPanel = false;
            gridviewSchedule.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridviewSchedule.ShowColumnHeaders = true;
            gridviewSchedule.AllowColumnHeaderContextMenu = true;
            gridviewSchedule.ShowRowHeaderColumn = false;
            gridviewSchedule.EnableFastScrolling = false;
            gridviewSchedule.SelectionMode = GridViewSelectionMode.FullRowSelect;
            #endregion

            LoadTimetable(typeOfPreview, ID);
        }

        void LoadTimetable(int typeOfPreview, long ID)
        {
            gridviewSchedule.Rows.Clear();

            var monday = new object[7];
            var tuesday = new object[7];
            var wednesday = new object[7];
            var thursday = new object[7];
            var friday = new object[7];

            if (typeOfPreview == TypeOfTimetablePreview.Class)
            {
                monday = GetLessonsByDayForClass(0, (int)ID);
                tuesday = GetLessonsByDayForClass(1, (int)ID);
                wednesday = GetLessonsByDayForClass(2, (int)ID);
                thursday = GetLessonsByDayForClass(3, (int)ID);
                friday = GetLessonsByDayForClass(4, (int)ID);
                
                #region the F of the timetable preview
                var monday1 = new object[7];
                int i = 0;
                foreach (var m in monday)
                {
                    if (m != null)
                    {
                        monday1[i] = m;
                        i++;
                    }
                }
                var tuesday1 = new object[7];
                i = 0;
                foreach (var m in tuesday)
                {
                    if (m != null)
                    {
                        tuesday1[i] = m;
                        i++;
                    }
                }
                var wednesday1 = new object[7];
                i = 0;
                foreach (var m in wednesday)
                {
                    if (m != null)
                    {
                        wednesday1[i] = m;
                        i++;
                    }
                }
                var thursday1 = new object[7];
                i = 0;
                foreach (var m in thursday)
                {
                    if (m != null)
                    {
                        thursday1[i] = m;
                        i++;
                    }
                }
                var friday1 = new object[7];
                i = 0;
                foreach (var m in friday)
                {
                    if (m != null)
                    {
                        friday1[i] = m;
                    }
                }

                monday = monday1;
                tuesday = tuesday1;
                wednesday = wednesday1;
                thursday = thursday1;
                friday = friday1;
                
#endregion
                 
            }

            else if (typeOfPreview == TypeOfTimetablePreview.Teacher)
            {
                monday = GetLessonsByDayForTeacher(0, ID);
                tuesday = GetLessonsByDayForTeacher(1, ID);
                wednesday = GetLessonsByDayForTeacher(2, ID);
                thursday = GetLessonsByDayForTeacher(3, ID);
                friday = GetLessonsByDayForTeacher(4, ID);
            }

            else if (typeOfPreview == TypeOfTimetablePreview.Classroom)
            {
                monday = GetLessonsByDayForClassroom(0, (int)ID);
                tuesday = GetLessonsByDayForClassroom(1, (int)ID);
                wednesday = GetLessonsByDayForClassroom(2, (int)ID);
                thursday = GetLessonsByDayForClassroom(3, (int)ID);
                friday = GetLessonsByDayForClassroom(4, (int)ID);
            }

            gridviewSchedule.Rows.Add("1", monday[0], tuesday[0], wednesday[0], thursday[0], friday[0]);
            gridviewSchedule.Rows.Add("2", monday[1], tuesday[1], wednesday[1], thursday[1], friday[1]);
            gridviewSchedule.Rows.Add("3", monday[2], tuesday[2], wednesday[2], thursday[2], friday[2]);
            gridviewSchedule.Rows.Add("4", monday[3], tuesday[3], wednesday[3], thursday[3], friday[3]);
            gridviewSchedule.Rows.Add("5", monday[4], tuesday[4], wednesday[4], thursday[4], friday[4]);
            gridviewSchedule.Rows.Add("6", monday[5], tuesday[5], wednesday[5], thursday[5], friday[5]);
            gridviewSchedule.Rows.Add("7", monday[6], tuesday[6], wednesday[6], thursday[6], friday[6]);


            
            int rowHeight = 65;
            foreach (var row in gridviewSchedule.Rows)
            {
                row.Height = rowHeight;
            }
        }

        object[] GetLessonsByDayForClass(int dayIndex, int ID)
        {
            object[] day = new object[7];
            object classTimetable = new Object(); 
            foreach (var cl in mDBManager.Timetable[dayIndex].Classes)
            {
                if (cl.Class.ID == ID)
                {
                    classTimetable = cl;
                }
            }
            for (int j = 0; j < (classTimetable as ClassSchedule).Lessons.Count; j++)
            {
                if ((classTimetable as ClassSchedule).Lessons[j] != null)
                {
                    day[j] = (classTimetable as ClassSchedule).Lessons[j].Subject.Name + Environment.NewLine +
                        "с " + (classTimetable as ClassSchedule).Lessons[j].Groups[0].Teacher.FirstName +
                        " " + (classTimetable as ClassSchedule).Lessons[j].Groups[0].Teacher.LastName;
                    try
                    {
                        day[j] += Environment.NewLine + "в стая" + Environment.NewLine + 
                            (classTimetable as ClassSchedule).Lessons[j].Groups[0].Room.Name;
                    }
                    catch { }
                }
                else
                {
                    day[j] = null;
                }
            }
            return day;
        }

        object[] GetLessonsByDayForTeacher(int dayIndex, long ID)
        {
            object[] day = new object[64];
            foreach (var cl in mDBManager.Timetable[dayIndex].Classes)
            {
                for (int i = 0; i < cl.Lessons.Count; i++ )
                {
                    try
                    {
                        if (cl.Lessons[i].Groups[0].Teacher.ID == ID)
                        {
                            day[i] = cl.Lessons[i].Groups[0].Teacher.FirstName + " " + cl.Lessons[i].Groups[0].Teacher.LastName + Environment.NewLine +
                                cl.Lessons[i].Subject.Name + Environment.NewLine +
                                cl.Class.Name + Environment.NewLine +
                                cl.Lessons[i].Groups[0].Room.Name;
                        }
                    }
                    catch { }
                }
            }
            return day;
        }

        object[] GetLessonsByDayForClassroom(int dayIndex, int ID)
        {
            object[] day = new object[64];
            foreach (var cl in mDBManager.Timetable[dayIndex].Classes)
            {
                for (int i = 0; i < cl.Lessons.Count; i++)
                {
                    try
                    {
                        if (cl.Lessons[i].Groups[0].Room.ID == ID)
                        {
                            day[i] = cl.Lessons[i].Groups[0].Room.Name + Environment.NewLine +
                                cl.Class.Name + Environment.NewLine +
                                cl.Lessons[i].Groups[0].Teacher.Name +
                                cl.Lessons[i].Subject.Name + Environment.NewLine;
                        }
                    }
                    catch { }
                }
            }
            return day;
        }
    }
}
