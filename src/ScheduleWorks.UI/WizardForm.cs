using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ScheduleWorks.Utility;
using ScheduleWorks.DBImport;

namespace ScheduleWorks.UI
{
    public partial class WizardForm : Telerik.WinControls.UI.RadForm
    {

        DBManager mDBManager;
        private bool closedWithOK = false;
        private bool editingInformation = false;

        public WizardForm(DBManager aDBManager)
        {
            InitializeComponent();
            mDBManager = aDBManager;

            editingInformation = mDBManager.isAddedInformationThroughTheWizard;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            try
            {
                schoolNameTextbox.Text = mDBManager.SchoolName;
                schoolYearTextbox.Text = mDBManager.AcademicYear;
                filePathLabel.Text = mDBManager.DBImportPath;
                
            }
            catch { }

        }

        private void browseForDBFileButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = @"c:\";
            openDialog.Filter = "Access database files (*.mdb)|*.mdb";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;
            openDialog.Multiselect = false;

            string filePath = "";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openDialog.FileName.ToString();
                filePathLabel.Text = filePath;

                Import import = new Import(filePath);

                foreach (Curriculum c in import.Curriculums)
                {
                    mDBManager.Lessons.Add(c);
                }
                foreach (Teacher t in import.Teachers)
                {
                    if (t.Color == Color.Empty)
                    {
                        t.Color = RandomColor.GetRandomColor();
                    }
                    mDBManager.Teachers.Add(t);
                }
                foreach (Subject s in import.Subjects)
                {
                    if (s.Color == Color.Empty)
                    {
                        s.Color = RandomColor.GetRandomColor();
                    }
                    mDBManager.Subjects.Add(s);
                }
                foreach (Class c in import.Classes)
                {
                    if (c.Color == Color.Empty)
                    {
                        c.Color = RandomColor.GetRandomColor();
                    }
                    mDBManager.Classes.Add(c);
                }
            }
        }

        private void addRoomsInformationButton_Click(object sender, EventArgs e)
        {
            ManageDatabaseForm manageDabaseForm = new ManageDatabaseForm(mDBManager);
            manageDabaseForm.pageviewManageDatabase.SelectedPage = manageDabaseForm.pageClassrooms;
            manageDabaseForm.Show();
        }

        private void subjectsDifficultyButton_Click(object sender, EventArgs e)
        {
            ManageDatabaseForm manageDabaseForm = new ManageDatabaseForm(mDBManager);
            manageDabaseForm.pageviewManageDatabase.SelectedPage = manageDabaseForm.pageSubjects;
            manageDabaseForm.Show();
        }

        private void wizardFinishedButton_Click(object sender, EventArgs e)
        {
            mDBManager.SchoolName = schoolNameTextbox.Text;
            mDBManager.AcademicYear = schoolYearTextbox.Text;
            mDBManager.DBImportPath = filePathLabel.Text;
            mDBManager.isAddedInformationThroughTheWizard = true;
            closedWithOK = true;
            this.Close();
        }

        private void WizardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!closedWithOK && !editingInformation)
            {
                mDBManager.Classes.Clear();
                mDBManager.Classrooms.Clear();
                mDBManager.Lessons.Clear();
                mDBManager.Subjects.Clear();
                mDBManager.Teachers.Clear();
            }
        }

        private void parametersButton_Click(object sender, EventArgs e)
        {
            EditParametersForm editParams = new EditParametersForm(mDBManager);
            editParams.Show();
        }
    }
}
