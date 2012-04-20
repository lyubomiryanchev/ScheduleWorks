using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Telerik.WinControls.Primitives;
using System.IO;
using ScheduleWorks.Utility;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Telerik.WinControls.UI.Export.ExcelML;
using Telerik.WinControls.UI.Export;


namespace ScheduleWorks.UI
{
	public delegate void AlgorithmStartHandler(DBManager db, int days, int periods, AlgorithmParameters Params);
	public delegate void AlgorithmStopHandler();
	public delegate bool AlgorithmCheckFinishedHandler();
	public delegate List<Utility.Day> AlgorithmGetGeneratedScheduleHandler();
    public partial class MainForm : RadRibbonForm
    {
        private DBManager mDBManager;
        public event AlgorithmStartHandler AlgorithmStart;
        public event AlgorithmStopHandler AlgorithmStop;
        public event AlgorithmCheckFinishedHandler AlgorithmCheckFinished;
		public event AlgorithmGetGeneratedScheduleHandler AlgorithmGetGenerated;
        ManageDatabaseForm manageDBForm;
        List<RadGridView> gridviews = new List<RadGridView>();

        public MainForm(DBManager dbManag)
        {
            InitializeComponent();

            mDBManager = dbManag;

            headerBar.OptionsButton.Visibility = ElementVisibility.Hidden;
            headerBar.ExitButton.Visibility = ElementVisibility.Hidden;


            #region Setting DropDownLists
            dropDownListTypeOfTimetablePreview.Items.Add(new RadListDataItem(){ 
                Tag = TypeOfTimetablePreview.Teacher, 
                Text = "Учители"
            });

            dropDownListTypeOfTimetablePreview.Items.Add(new RadListDataItem(){
                Tag = TypeOfTimetablePreview.Class, 
                Text = "Класове"
            });

            dropDownListTypeOfTimetablePreview.Items.Add(new RadListDataItem(){
                Tag = TypeOfTimetablePreview.Classroom, 
                Text = "Стаи"
            });

            dropDownListElementOfTimetablePreview.DropDownStyle = RadDropDownStyle.DropDownList;
            dropDownListTypeOfTimetablePreview.DropDownStyle = RadDropDownStyle.DropDownList;
            #endregion

            #region Button properties setting
            tabHomeGroupFilesButtonNewFile.ShowBorder = false;
            tabHomeGroupFilesButtonOpenFile.ShowBorder = false;
            tabHomeGroupFilesButtonSaveFile.ShowBorder = false;
            tabHelpGroupDocumentationButtonHelp.ShowBorder = false;

            tabHomeGroupOperationsButtonClasses.ShowBorder = false;
            tabHomeGroupOperationsButtonClassrooms.ShowBorder = false;
            tabHomeGroupOperationsButtonSubjects.ShowBorder = false;
            tabHomeGroupOperationsButtonTeachers.ShowBorder = false;
            tabHomeGroupOperationsButtonLessons.ShowBorder = false;

            tabHomeGroupOthersButtonHelper.ShowBorder = false;

            buttonParameters.ShowBorder = false;
            #endregion

            
            #region Unuseful code for managing new page in documentTabStrip
            /*
            documentTabStrip1.Controls.Add(new DocumentWindow("bllq"));
            documentTabStrip1.Controls.Add(new DocumentWindow("bllq2"));


            documentTabStrip1.Controls[0].Controls.Add(new TimetableGridview(mDBManager, -1)
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Width = documentTabStrip1.TabPanels[0].Width,
                Height = documentTabStrip1.TabPanels[0].Height
            });

            documentTabStrip1.Controls[1].Controls.Add(new TimetableGridview(mDBManager, -1)
            { 
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top, 
                Width = documentTabStrip1.TabPanels[1].Width, 
                Height = documentTabStrip1.TabPanels[1].Height 
            });

            documentTabStrip1.Controls[2].Controls.Add(new TimetableGridview(mDBManager, -1)
            { 
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top, 
                Width = documentTabStrip1.TabPanels[2].Width, 
                Height = documentTabStrip1.TabPanels[2].Height 
            });
            */
            #endregion
        }

        bool scheduleMadeNew = false;

        #region Buttons OnClick events handling
        private void buttonClassesClick(object sender, EventArgs e)
        {
            manageDBForm = new ManageDatabaseForm(mDBManager);
            manageDBForm.pageviewManageDatabase.SelectedPage = manageDBForm.pageClasses;
            manageDBForm.Show();
        }
        private void buttonClassroomsClick(object sender, EventArgs e)
        {
            manageDBForm = new ManageDatabaseForm(mDBManager);
            manageDBForm.pageviewManageDatabase.SelectedPage = manageDBForm.pageClassrooms;
            manageDBForm.Show();
        }
        private void buttonSubjectsClick(object sender, EventArgs e)
        {
            manageDBForm = new ManageDatabaseForm(mDBManager);
            manageDBForm.pageviewManageDatabase.SelectedPage = manageDBForm.pageSubjects;
            manageDBForm.Show();

        }
        private void buttonTeachersClick(object sender, EventArgs e)
        {
            manageDBForm = new ManageDatabaseForm(mDBManager);
            manageDBForm.pageviewManageDatabase.SelectedPage = manageDBForm.pageTeachers;
            manageDBForm.Show();
        }
        private void buttonLessonsClick(object sender, EventArgs e)
        {
            manageDBForm = new ManageDatabaseForm(mDBManager);
            manageDBForm.pageviewManageDatabase.SelectedPage = manageDBForm.pageLessons;
            manageDBForm.Show();
        }
        private void buttonHelperClick(object sender, EventArgs e)
        {
            WizardForm wizard = new WizardForm(mDBManager);
            wizard.Show();
        }
        private void tabHomeGroupFilesButtonSaveFile_Click(object sender, EventArgs e)
        {
            scheduleMadeNew = false;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = @"c:\";
            saveDialog.Filter = "ScheduleWorks Project File (*.swd)|*.swd";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;

            string filePath = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = saveDialog.FileName.ToString();

                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                    formatter.Serialize(stream, mDBManager);
                    stream.Close();
                }
                catch (UnauthorizedAccessException)
                {
                    RadMessageBox.Show("Моля, изберете директория за файла, в която имате права да записвате файлове. Често, макар и с администраторки акаунт, нямате право да записвате файлове на системния диск!", "Грешка!");
                }
            }

        }

        bool scheduleOpened = false;
        private void tabHomeGroupFilesButtonOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.DialogResult.OK;
            if (scheduleMadeNew)
            {
                dialogResult = RadMessageBox.Show("Има промени по предишното разписание, сигурни ли сте, че искате да отворите ново? Всички промени ще бъдат загубени.", "Внимание!", MessageBoxButtons.OKCancel);
            }
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                scheduleMadeNew = false;

                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.InitialDirectory = @"c:\";
                openDialog.Filter = "ScheduleWorks Project File (*.swd)|*.swd";
                openDialog.FilterIndex = 2;
                openDialog.RestoreDirectory = true;
                openDialog.Multiselect = false;

                string filePath = "";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openDialog.FileName.ToString();

                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                        mDBManager = (DBManager)formatter.Deserialize(stream);
                        IndexMaker.LastIndexOfClassrooms = mDBManager.Classrooms.Count - 1;
                        IndexMaker.LastIndexOfClasses = mDBManager.Classes.Count - 1;
                        IndexMaker.LastIndexOfTeachers = mDBManager.Teachers.Count - 1;
                        IndexMaker.LastIndexOfSubjects = mDBManager.Subjects.Count - 1;
                        IndexMaker.LastIndexOfLessons = mDBManager.Lessons.Count - 1;
                        Console.WriteLine("File loaded!");
                        stream.Close();
                        scheduleOpened = true;
                        //LoadTimetable();
                    }
                    catch
                    {
                        RadMessageBox.Show("Неизвестна грешка. Моля, свържете се с администратор!", "Грешка!");
                    }
                }
            }
        }

        System.Threading.Thread generateTimetableScreenFormThread;


        Random rand = new Random();
        HomeScreenForm generateTimetableScreenForm;
        private void buttonGenerateTimetable_Click(object sender, EventArgs e)
        {
            #region old shuffleing
            /*foreach (var cl in mDBManager.Classes)
            {
                gridViewClassName.Rows.Add(cl.ShortName);
                List<int> usedLessonsID = new List<int>();
                foreach(Curriculum l in mDBManager.Lessons){
                    bool[,] usedCells = bool[5,7];
                    if (l.Class.ID == cl.ID)
                    {
                        bool used = false;
                        foreach(var usedLesson in usedLessonsID){
                            if (l.ID == usedLesson)
                            {
                                used = true;
                                break;
                            }
                        }
                        if (!used)
                        {
                            int randDay = rand.Next(5);
                            int randPosition = rand.Next(7);
                            while (usedCells[randDay, randPosition])
                            {
                                randDay = rand.Next(5);
                                randPosition = rand.Next(7);
                            }
                            usedCells[randDay, randPosition] = true;
                            usedLessonsID.Add(l.ID);
                            switch (randDay)
	                        {
		                        case 0:
                                    //gridviewMonday.Rows[
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    break;
                                case 6:
                                    break;
	                        }
                        }
                    }
                }
            }*/
            #endregion
            try
            {
                this.Enabled = false;
                Algorithm.GenerationAlgorithm ga = new Algorithm.GenerationAlgorithm();
                ga.BeginInit();
                ga.Days = 5;
                ga.PeriodsCount = 7;
                List<Curriculum> data = mDBManager.Lessons;
                ga.Data = data;
                ga.SubjectsDifficulty = mDBManager.AlgorithmParameters;
                try
                {
                    ga.EndInit();
                }
                catch (Exception exception)
                {

                }
                //System.Threading.Thread.Sleep(1000 * 60 * 2);
                /*
                int cnt;
                for (int day = 0; day < ga.Generated.Timetable.Count; ++day)
                {
                    for (int classN = 0; classN < ga.Generated.Timetable[day].Classes.Count; ++classN)
                    {
                        cnt = 0;
                        for (int lesson = 0; lesson < ga.Generated.Timetable[day].Classes[classN].Lessons.Count; ++lesson)
                        {
                            if (ga.Generated.Timetable[day].Classes[classN].Lessons[lesson] != null)
                            {
                                ga.Generated.Timetable[day].Classes[classN].Lessons[cnt] = ga.Generated.Timetable[day].Classes[classN].Lessons[lesson];
                                cnt++;
                            }
                        }
                    }
                }
                 */
                this.mDBManager.Timetable = ga.Generated.Timetable;

                //LoadTimetable();
            }
            catch
            {
                RadMessageBox.Show("Неизвестна грешка, моля, свържете се с администратор!", "Грешка!");
            }
            
            this.Enabled = true;

            //AlgorithmStart(mDBManager, 5, 7, mDBManager.AlgorithmParameters);


        }
        private void buttonParameters_Click(object sender, EventArgs e)
        {
            EditParametersForm editParams = new EditParametersForm(mDBManager);
            editParams.Show();
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

        private void printTheScheduleButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = @"c:\";
            saveDialog.Filter = "Excell File (*.xls)|*.xls";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;

            string filePath = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveDialog.FileName.ToString();
                ExportToExcelML exporter = new ExportToExcelML(
                    (documentTabStrip1.TabPanels[documentTabStrip1.SelectedIndex].Controls[0] as TimetableGridview).gridviewSchedule);
                exporter.HiddenColumnOption = Telerik.WinControls.UI.Export.HiddenOption.DoNotExport;
                exporter.ExportVisualSettings = true;
                exporter.SheetName = "Разписание за " + documentTabStrip1.TabPanels[0].Text.ToString();
                exporter.ExcelCellFormatting += exporter_ExcelCellFormatting;
                exporter.RunExport(filePath);
            }
            //PrintTheScheduleForm printSchedule = new PrintTheScheduleForm(mDBManager);
            //printSchedule.Show();
        }

        #endregion


        #region Handleing events for the timetable preview gridviews
        private void gridview_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                foreach (var subject in mDBManager.Subjects)
                {
                    if (e.CellElement.Tag != null)
                    {
                        if (int.Parse(e.CellElement.Tag.ToString()) == subject.ID)
                        {
                            e.CellElement.BackColor = subject.Color;
                            e.CellElement.Text = subject.ShortName;
                            break;
                        }
                    }
                }

                e.CellElement.TextAlignment = ContentAlignment.BottomCenter;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = GradientStyles.Solid;
            }
            catch { }

        }

        private void gridviews_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            foreach (var g in gridviews)
            {                
                g.CurrentRow = e.CurrentRow;
                foreach (var row in g.Rows)
                {
                    try
                    {
                        row.IsSelected = false;
                        if (row.Index == e.CurrentRow.Index)
                        {
                            row.IsSelected = true;
                        }
                    }
                    catch { }
                }
            }
        }
        #endregion

        public void AlgorithmFinished()
		{
            this.Enabled = true;
            //generateTimetableScreenFormThread.Abort();
			mDBManager.Timetable = AlgorithmGetGenerated();
			if (this.InvokeRequired)
			{
				//TODO
			}
			else
			{
                Console.WriteLine("Algorithm finished");
                RadMessageBox.Show("Генерирането на разписанието е завършено!", "Внимание!");
                this.Enabled = true;
				//LoadTimetable
			}
		}

		public void SendMessage(string message)
		{
			
		}

        private void tabHomeGroupFilesButtonNewFile_Click(object sender, EventArgs e)
        {
            var dialogResult = RadMessageBox.Show("Сигурни ли сте, че искате да направите нов файл? Всички промени по сегашният ще бъдат загубени.", "Внимание!", MessageBoxButtons.OKCancel);
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                scheduleMadeNew = true;
                mDBManager = new DBManager();
                //LoadTimetable();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            WizardForm wizard = new WizardForm(mDBManager);
            wizard.Show();
        }

        int typeOfTimetablePreview = -1;
        bool pauseDropDownListElements = false;

        private void dropDownListTypeOfTimetablePreview_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            pauseDropDownListElements = true;
            switch ((int)(dropDownListTypeOfTimetablePreview.SelectedItem.Tag))
            {
                case TypeOfTimetablePreview.Teacher: // Teachers
                    dropDownListElementOfTimetablePreview.Items.Clear();
                    foreach(var teacher in  mDBManager.Teachers){
                        dropDownListElementOfTimetablePreview.Items.Add(
                            new RadListDataItem()
                            {
                                Text = teacher.Name, 
                                Tag = teacher.ID
                            }
                        );
                    }
                    typeOfTimetablePreview = TypeOfTimetablePreview.Teacher;
                    break;

                case TypeOfTimetablePreview.Class: // Classes
                    dropDownListElementOfTimetablePreview.Items.Clear();
                    foreach(var cl in  mDBManager.Classes){
                        dropDownListElementOfTimetablePreview.Items.Add(
                            new RadListDataItem()
                            {
                                Text = cl.Name, 
                                Tag = cl.ID
                            }
                        );
                    }
                    typeOfTimetablePreview = TypeOfTimetablePreview.Class;
                    break;

                case TypeOfTimetablePreview.Classroom: // Classrooms
                    dropDownListElementOfTimetablePreview.Items.Clear();
                    foreach(var classroom in  mDBManager.Classrooms){
                        dropDownListElementOfTimetablePreview.Items.Add(
                            new RadListDataItem()
                            {
                                Text = classroom.Name, 
                                Tag = classroom.ID
                            }
                        );
                    }
                    typeOfTimetablePreview = TypeOfTimetablePreview.Classroom;
                    break;
            }
            pauseDropDownListElements = false;
        }

        private void dropDownListElementOfTimetablePreview_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (typeOfTimetablePreview != -1 && !pauseDropDownListElements)
            {
                try
                {
                    MakeNewTabAndLoad(typeOfTimetablePreview,
                        (long)dropDownListElementOfTimetablePreview.SelectedItem.Tag,
                        dropDownListElementOfTimetablePreview.SelectedItem.Text);
                }
                catch
                {
                    try
                    {
                        long a = 0;
                        a += (int)dropDownListElementOfTimetablePreview.SelectedItem.Tag;
                        MakeNewTabAndLoad(typeOfTimetablePreview, a, dropDownListElementOfTimetablePreview.SelectedItem.Text);
                    }
                    catch { }
                }
            }
        }

        private void MakeNewTabAndLoad(int typeOfPreview, long ID, string aName)
        {
            documentTabStrip1.Controls.Add(new DocumentWindow(aName)); 

            documentTabStrip1.Controls[documentTabStrip1.Controls.Count - 1].Controls.Add(new TimetableGridview(mDBManager, typeOfTimetablePreview, ID)
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Width = documentTabStrip1.TabPanels[documentTabStrip1.TabPanels.Count-1].Width,
                Height = documentTabStrip1.TabPanels[documentTabStrip1.TabPanels.Count-1].Height
            });
        }
    }
}
