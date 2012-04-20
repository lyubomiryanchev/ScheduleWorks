using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using ScheduleWorks.Utility;
using Telerik.WinControls.UI.Export.ExcelML;
using System.Linq;

namespace ScheduleWorks.UI
{
    public partial class PrintTheScheduleForm : Telerik.WinControls.UI.RadForm
    {
        DBManager mDBManager;
        public PrintTheScheduleForm(DBManager aDBManager)
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


            try
            {
                int i = 0;
                foreach (var c in mDBManager.Timetable[0].Classes)
                {
                    dropdownListClasses.Items.Add(new RadListDataItem(c.Class.Name) { Tag = i });
                    i++;
                }
            }
            catch { }
        }


        void LoadTimetable(int classIndex)
        {
            gridviewSchedule.Rows.Clear();
            try
            {
                var monday = GetLessonsByDay(0, classIndex);
                //var monday1 = new List<object>(monday);
                //monday1.Sort();
                //monday1.Reverse();
                //monday = monday1.ToArray();
                var tuesday = GetLessonsByDay(1, classIndex);
                //var monday2 = new List<object>(tuesday);
                //monday2.Sort();
                //monday2.Reverse();
                //tuesday = monday2.ToArray();
                var wednesday = GetLessonsByDay(2, classIndex);
                //var monday3 = new List<object>(wednesday);
                //monday3.Sort();
                //monday3.Reverse();
                //wednesday = monday3.ToArray();
                var thursday = GetLessonsByDay(3, classIndex);
                //var monday4 = new List<object>(thursday);
                //monday4.Sort();
                //monday4.Reverse();
                //thursday = monday4.ToArray();
                var friday = GetLessonsByDay(4, classIndex);
                //var monday5 = new List<object>(friday);
                //monday5.Sort();
                //monday5.Reverse();
                //friday = monday5.ToArray();

                int rowHeight = 65; 

                gridviewSchedule.Rows.Add("1", monday[0], tuesday[0], wednesday[0], thursday[0], friday[0]);
                gridviewSchedule.Rows.Add("2", monday[1], tuesday[1], wednesday[1], thursday[1], friday[1]);
                gridviewSchedule.Rows.Add("3", monday[2], tuesday[2], wednesday[2], thursday[2], friday[2]);
                gridviewSchedule.Rows.Add("4", monday[3], tuesday[3], wednesday[3], thursday[3], friday[3]);
                gridviewSchedule.Rows.Add("5", monday[4], tuesday[4], wednesday[4], thursday[4], friday[4]);
                gridviewSchedule.Rows.Add("6", monday[5], tuesday[5], wednesday[5], thursday[5], friday[5]);
                gridviewSchedule.Rows.Add("7", monday[6], tuesday[6], wednesday[6], thursday[6], friday[6]);

                foreach (var row in gridviewSchedule.Rows)
                {
                    row.Height = rowHeight;
                }
            }
            catch
            {
            }
        }

        object[] GetLessonsByDay(int dayIndex, int classIndex)
        {
            object[] day = new object[mDBManager.Timetable[dayIndex].Classes[classIndex].Lessons.Count];
            for (int j = 0; j < mDBManager.Timetable[dayIndex].Classes[classIndex].Lessons.Count; j++)
            {
                if (mDBManager.Timetable[dayIndex].Classes[classIndex].Lessons[j] != null)
                {
                    day[j] = mDBManager.Timetable[dayIndex].Classes[classIndex].Lessons[j].Subject.Name + Environment.NewLine + 
                        " с " + mDBManager.Timetable[dayIndex].Classes[classIndex].Lessons[j].Groups[0].Teacher.FirstName +  
                        " " + mDBManager.Timetable[dayIndex].Classes[classIndex].Lessons[j].Groups[0].Teacher.LastName;
                    try
                    {
                        day[j] += Environment.NewLine + " в стая " + mDBManager.Timetable[dayIndex].Classes[classIndex].Lessons[j].Groups[0].Room.Name;
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

        void exporter_ExcelCellFormatting(object sender, Telerik.WinControls.UI.Export.ExcelML.ExcelCellFormattingEventArgs e)
        {
            BorderStyles borderRight = new BorderStyles();
            borderRight.Color = Color.Black;
            borderRight.Weight = 1;
            borderRight.LineStyle = LineStyle.Continuous;
            borderRight.PositionType = PositionType.Right;
            e.ExcelStyleElement.Borders.Add(borderRight);

            BorderStyles borderLeft = new BorderStyles();
            borderLeft.Color = Color.Black;
            borderLeft.Weight = 1;
            borderLeft.LineStyle = LineStyle.Continuous;
            borderLeft.PositionType = PositionType.Left;
            e.ExcelStyleElement.Borders.Add(borderLeft);

            BorderStyles borderTop = new BorderStyles();
            borderTop.Color = Color.Black;
            borderTop.Weight = 1;
            borderTop.LineStyle = LineStyle.Continuous;
            borderTop.PositionType = PositionType.Top;
            e.ExcelStyleElement.Borders.Add(borderTop);

            BorderStyles borderBottom = new BorderStyles();
            borderBottom.Color = Color.Black;
            borderBottom.Weight = 1;
            borderBottom.LineStyle = LineStyle.Continuous;
            borderBottom.PositionType = PositionType.Bottom;
            e.ExcelStyleElement.Borders.Add(borderBottom);

            if (e.GridRowInfoType == typeof(GridViewTableHeaderRowInfo))
            {
                e.ExcelStyleElement.FontStyle.Bold = true;
            }
            e.ExcelStyleElement.AlignmentElement.WrapText = true;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = @"c:\";
            saveDialog.Filter = "Excell File (*.xls)|*.xls";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;

            string filePath = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = saveDialog.FileName.ToString();
                    ExportToExcelML exporter = new ExportToExcelML(this.gridviewSchedule);
                    exporter.HiddenColumnOption = Telerik.WinControls.UI.Export.HiddenOption.DoNotExport;
                    exporter.ExportVisualSettings = true;
                    exporter.SheetName = "Разписание за " + dropdownListClasses.SelectedItem.Text;
                    exporter.ExcelCellFormatting += exporter_ExcelCellFormatting;
                    exporter.RunExport(filePath);
                }
                catch { }
            }
        }

        private void buttonLoadTimetable_Click(object sender, EventArgs e)
        {
            LoadTimetable((int)(dropdownListClasses.SelectedItem.Tag));
        }
    }
}
