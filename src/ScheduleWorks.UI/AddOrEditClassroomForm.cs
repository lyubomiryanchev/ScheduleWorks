using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ScheduleWorks.Utility;
using System.Linq;

namespace ScheduleWorks.UI
{
    public partial class AddOrEditClassroomForm : Telerik.WinControls.UI.RadForm
    {

        private long mHomeClassID = -1;
        private List<long> specialisatedSubjectsIDs;

        private DBManager mDBManager;
        private Classroom mClassroom;
        private long mID;
        private FormState mFormState;

        public AddOrEditClassroomForm(DBManager dbManage)
        {
            InitializeComponent();

            mDBManager = dbManage;
            this.Text = FormTitles.ClassroomForm.Add;
            mFormState = FormState.AddingNew;

            chooseHeadclassOfThisClassroom.Visible = false;
            chooseSubjectsToBeTaughtInThisRoomButton.Visible = false;

            isSpecializedRoomCheckbox.Checked = false;
            isHomeClassroomCheckbox.Checked = false;

            panelClassroomColor.BackColor = RandomColor.GetRandomColor();
        }

        public AddOrEditClassroomForm(DBManager dbManage, long aID)
        {
            InitializeComponent();
            
            mDBManager = dbManage;
            mID = aID;
            this.Text = FormTitles.ClassroomForm.Edit;
            mFormState = FormState.Editing;

            var room = from r in mDBManager.Classrooms
                        where r.ID == aID
                        select r;

            mClassroom = room.FirstOrDefault();

            nameTextbox.Text = mClassroom.Name;
            shortNameTextbox.Text = mClassroom.ShortName;
            if (mClassroom.Color != Color.Empty)
            {
                panelClassroomColor.BackColor = mClassroom.Color;
            }
            else
            {
                panelClassroomColor.BackColor = RandomColor.GetRandomColor();
            }
            isHomeClassroomCheckbox.Checked = mClassroom.IsHomeClassroom;
            this.mHomeClassID = mClassroom.HomeClassID;
            isSpecializedRoomCheckbox.Checked = mClassroom.IsSpecialisated;
            specialisatedSubjectsIDs = mClassroom.SpecialisatedSubjectsIDs;


            if (isSpecializedRoomCheckbox.Checked == true)
            {
                chooseSubjectsToBeTaughtInThisRoomButton.Visible = true;
            }
            else
            {
                chooseSubjectsToBeTaughtInThisRoomButton.Visible = false;
            }

            if (isHomeClassroomCheckbox.Checked == true)
            {
                chooseHeadclassOfThisClassroom.Visible = true;
            }
            else
            {
                chooseHeadclassOfThisClassroom.Visible = false;
            }
        }

        private void isSpecializedRoomCheckboxToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (isSpecializedRoomCheckbox.Checked == true)
            {
                chooseSubjectsToBeTaughtInThisRoomButton.Visible = true;
            }
            else
            {
                chooseSubjectsToBeTaughtInThisRoomButton.Visible = false;
            }
        }

        private void isHomeClassroomCheckboxToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (isHomeClassroomCheckbox.Checked == true)
            {
                chooseHeadclassOfThisClassroom.Visible = true;
            }
            else
            {
                chooseHeadclassOfThisClassroom.Visible = false;
            }
        }

        private void classroomNameTextboxTextChanged(object sender, EventArgs e)
        {
            int lettersToBeCopied = 3;
            #region Text manipulation
            if (nameTextbox.Text.Length != 0)
            {
                if (nameTextbox.Text.Length <= lettersToBeCopied)
                {
                    shortNameTextbox.Text = nameTextbox.Text;
                }
                else
                {
                    shortNameTextbox.Text = nameTextbox.Text.Substring(0, lettersToBeCopied);
                }
            }
            else
            {
                shortNameTextbox.Text = "";
            }
            #endregion
        }

        private bool mToCloseTheForm = false;

        private void checkFieldsAndAddOrEditClassroomInTheDB()
        {
            string name = nameTextbox.Text.ToString();
            string shortName = shortNameTextbox.Text.ToString();
            Color color = panelClassroomColor.BackColor;
            bool isHomeClassroom = isHomeClassroomCheckbox.Checked;
            long tHomeClassID = this.mHomeClassID;
            bool isSpecialisated = isSpecializedRoomCheckbox.Checked;
            List<long> specialisatedSubjectsIDs = this.specialisatedSubjectsIDs;

            #region Cheking the fields
            if (isHomeClassroom && mHomeClassID == -1)
            {
                RadMessageBox.Show("Моля, изберете клас, за който тази стая да бъде класна", "Грешка!");
                mToCloseTheForm = false;
                return;
            }
            if (isSpecialisated && specialisatedSubjectsIDs == null)
            {
                RadMessageBox.Show("Моля, изберете предметите, за който тази стая специализирана", "Грешка!");
                mToCloseTheForm = false;
                return;
            }


            int blankChars = 0;
            foreach(char ch in name)
            {
                if (ch == ' ') blankChars++;
            }

            if(name == "" || blankChars == name.Length){
                RadMessageBox.Show("Моля, въведете име на стаята", "Грешка!");
                mToCloseTheForm = false;
                return;
            }
            #endregion

            if (mFormState == FormState.AddingNew)
            {
                mDBManager.Classrooms.Add(
                    new Classroom(
                        name,
                        shortName,
                        color,
                        isHomeClassroom,
                        tHomeClassID,
                        isSpecialisated,
                        specialisatedSubjectsIDs
                    )
                );
            }
            else
            {
                int i = 0;
                foreach (Classroom r in mDBManager.Classrooms)
                {
                    if (mID == r.ID)
                    {
                        mDBManager.Classrooms[i].Name = name;
                        mDBManager.Classrooms[i].ShortName = shortName;
                        mDBManager.Classrooms[i].Color = color;
                        mDBManager.Classrooms[i].IsHomeClassroom = isHomeClassroom;
                        mDBManager.Classrooms[i].HomeClassID = mHomeClassID;
                        mDBManager.Classrooms[i].IsSpecialisated = isSpecialisated;
                        mDBManager.Classrooms[i].SpecialisatedSubjectsIDs = specialisatedSubjectsIDs;

                        return;
                    }
                    i++;
                }
            }
        }

        private void finishButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            mToCloseTheForm = true;

            checkFieldsAndAddOrEditClassroomInTheDB();

            if (mToCloseTheForm)
            {
                this.Close();
            }
        }

        private void changeClassroomColorButtonClick(object sender, EventArgs e)
        {
            RadColorDialog colorDialog = new RadColorDialog();
            colorDialog.SelectedColor = panelClassroomColor.BackColor;
            colorDialog.ShowDialog();
            panelClassroomColor.BackColor = colorDialog.SelectedColor;
        }

        private void AddOrEditClassroomFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            }
        }

        ChooseItemsForm chooseSubjectsToBeTaughtForm;
        private void chooseSubjectsToBeTaughtInThisRoomButton_Click(object sender, EventArgs e)
        {
            
            List<ChooseItemsParameters> subjects = new List<ChooseItemsParameters>();

            foreach (var s in mDBManager.Subjects)
            {
                subjects.Add(new ChooseItemsParameters(s.Name, s.ShortName, s.ID));
            }

            Console.WriteLine("Count of the subjects: {0}", subjects.Count);

            List<ChooseItemsParameters> alreadySpecialisatedSubjects = new List<ChooseItemsParameters>();
            try
            {
                foreach (var sID in specialisatedSubjectsIDs)
                {
                    foreach (var subject in mDBManager.Subjects)
                    {
                        if (sID == subject.ID)
                        {                                
                            alreadySpecialisatedSubjects.Add(new ChooseItemsParameters(subject.Name, subject.ShortName, subject.ID));
                        }
                    }
                }
            }
            catch { }
            try
            {
                chooseSubjectsToBeTaughtForm.gridviewItems.Rows.Clear();
            }
            catch { } 
            chooseSubjectsToBeTaughtForm = new ChooseItemsForm(ChooseItems.Mode.MultipleItems, "Избери предмети, които да се преподават в тази стая", subjects, alreadySpecialisatedSubjects);
            chooseSubjectsToBeTaughtForm.OnReadyButtonClicked += chooseSubjectsToBeTaught_OnReadyButtonClicked;
            chooseSubjectsToBeTaughtForm.Show();
        }


        ChooseItemsForm chooseHeadclassOfThisClassroomForm;
        private void chooseHeadclassOfThisClassroom_Click(object sender, EventArgs e)
        {
            if (mFormState == FormState.AddingNew)
            {
                List<ChooseItemsParameters> classes = new List<ChooseItemsParameters>();
                foreach (var s in mDBManager.Classes)
                {
                    classes.Add(new ChooseItemsParameters(s.Name, s.ShortName, s.ID));
                }
                chooseHeadclassOfThisClassroomForm = new ChooseItemsForm(ChooseItems.Mode.SingleItem, "Избери клас, на който тази стая да бъде класна стая", classes);
            }
            if (mFormState == FormState.Editing)
            {
                List<ChooseItemsParameters> classes = new List<ChooseItemsParameters>();
                foreach (var s in mDBManager.Classes)
                {
                    classes.Add(new ChooseItemsParameters(s.Name, s.ShortName, s.ID));
                }

                List<ChooseItemsParameters> alreadyChoosedClass = new List<ChooseItemsParameters>();
                Class choosedClass = mDBManager.Classes[0];
                foreach(Class c in mDBManager.Classes){
                    if(c.ID == mHomeClassID){
                        choosedClass = c;
                        break;
                    }
                }
                alreadyChoosedClass.Add(new ChooseItemsParameters(choosedClass.Name, choosedClass.Name, choosedClass.ID));
                chooseHeadclassOfThisClassroomForm = new ChooseItemsForm(ChooseItems.Mode.SingleItem, "Избери клас, на който тази стая да бъде класна стая", classes, alreadyChoosedClass);
            }
            chooseHeadclassOfThisClassroomForm.OnReadyButtonClicked += chooseHeadclassOfThisClassroom_OnReadyButtonClicked;
            chooseHeadclassOfThisClassroomForm.Show();
        }

        void chooseSubjectsToBeTaught_OnReadyButtonClicked(object sender, EventArgs e)
        {
            if (specialisatedSubjectsIDs == null)
            {
                specialisatedSubjectsIDs = new List<long>();
            }
            specialisatedSubjectsIDs.Clear();
            foreach (var i in chooseSubjectsToBeTaughtForm.GetSelectedItems())
            {
                specialisatedSubjectsIDs.Add(long.Parse(i.ToString()));
            }
        }

        void chooseHeadclassOfThisClassroom_OnReadyButtonClicked(object sender, EventArgs e)
        {
            foreach (var i in chooseHeadclassOfThisClassroomForm.GetSelectedItems())
            {
                mHomeClassID = long.Parse(i.ToString());
            }
            chooseHeadclassOfThisClassroomForm.Dispose();
        }
    }
}
