using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using ScheduleWorks.Utility;

namespace ScheduleWorks.UI
{
    public partial class AddOrEditClassForm : Telerik.WinControls.UI.RadForm
    {
        private DBManager mDBManager;
        private FormState mFormState;
        private Class mClass;
        public long mID;

        private Teacher mHeadTeacher;


        public AddOrEditClassForm(DBManager dbManag)
        {
            InitializeComponent();
            mDBManager = dbManag;

            this.Text = FormTitles.ClassForm.Add;
            mFormState = FormState.AddingNew;

            RadListDataItem dropDownItem = new RadListDataItem("1");
            dropDownItem.Value = 1;
            dropDownItem.Selected = true;
            gradeDropdownlist.Items.Add(dropDownItem);
            for (int i = 2; i <= 12; ++i)
            {
                dropDownItem = new RadListDataItem(i.ToString());
                dropDownItem.Value = i;
                gradeDropdownlist.Items.Add(dropDownItem);
            }

            importTeachersFromTheDatabase();

            changingHeadteacherReadyButton.Visible = false;
            teachersDropdownlist.Visible = false;

            changeHeadTeacherButton.Visible = false;
            changingHeadteacherReadyButton.Visible = true;
            teachersDropdownlist.Visible = true;

            colorPanel.BackColor = RandomColor.GetRandomColor();

            gradeDropdownlist.DropDownStyle = RadDropDownStyle.DropDownList;
            teachersDropdownlist.DropDownStyle = RadDropDownStyle.DropDownList;
        }

        

        public AddOrEditClassForm(DBManager dbManag, int aID)
        {
            InitializeComponent();

            mDBManager = dbManag;
            mID = aID;

            var cl = from c in mDBManager.Classes
                    where c.ID == aID
                    select c;
            mClass = cl.FirstOrDefault();
            
            this.Text = FormTitles.ClassForm.Edit;
            mFormState = FormState.Editing;

            

            nameTextbox.Text = mClass.Name;
            shortNameTextbox.Text = mClass.ShortName;

            long headTeacherID = -1;
            foreach (Teacher t in mDBManager.Teachers)
            {
                if (t.ID == mClass.HeadTeacherID)
                {
                    headTeacherID = t.ID;
                    break;
                }
            }

            Teacher teacher = null;
            foreach (var t in mDBManager.Teachers)
            {
                if (t.ID == headTeacherID)
                {
                    teacher = t;
                }
            }

            if (teacher != null)
            {
                this.mHeadTeacher = teacher;
                headTeacherNameLabel.Text = this.mHeadTeacher.Name;

                changingHeadteacherReadyButton.Visible = false;
                teachersDropdownlist.Visible = false;
            }

            else
            {
                changeHeadTeacherButton.Visible = false;
                changingHeadteacherReadyButton.Visible = true;
                teachersDropdownlist.Visible = true;
            }

            if (mClass.Color != Color.Empty)
            {
                colorPanel.BackColor = mClass.Color;
            }
            else{
                colorPanel.BackColor = RandomColor.GetRandomColor();
            }

            RadListDataItem dropDownItem = new RadListDataItem("1");
            dropDownItem.Value = 1;
            gradeDropdownlist.Items.Add(dropDownItem);
            for(int i = 2; i <= 12; ++i){
                dropDownItem = new RadListDataItem(i.ToString());
                dropDownItem.Value = i;
                gradeDropdownlist.Items.Add(dropDownItem);
            }

            try
            {
                gradeDropdownlist.Items[mClass.Grade - 1].Selected = true;
            }
            catch { }
            
            importTeachersFromTheDatabase();
        }

        private void importTeachersFromTheDatabase()
        {
            int i = 0;
            foreach(Teacher t in mDBManager.Teachers)
            {
                RadListDataItem item = new RadListDataItem(t.Name);
                item.Value = t.ID;
                try
                {
                    if ((long)item.Value == mHeadTeacher.ID)
                    {
                        item.Selected = true;
                    }
                }
                catch { }
                teachersDropdownlist.Items.Add(item);
                i++;
            }
        }

        private void changeColorButtonClicked(object sender, EventArgs e)
        {
            RadColorDialog colorDialog = new RadColorDialog();
            colorDialog.SelectedColor = colorPanel.BackColor;
            colorDialog.ShowDialog();
            colorPanel.BackColor = colorDialog.SelectedColor;
        }

        private void nameTextboxTextChanged(object sender, EventArgs e)
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

        private void changeHeadTeacherButtonClick(object sender, EventArgs e)
        {
            changeHeadTeacherButton.Visible = false;
            changingHeadteacherReadyButton.Visible = true;
            teachersDropdownlist.Visible = true;
        }

        private void changingHeadteacherReadyButtonClick(object sender, EventArgs e)
        {
            if (teachersDropdownlist.SelectedItem != null)
            {
                changeHeadTeacherButton.Visible = true;
                changingHeadteacherReadyButton.Visible = false;
                teachersDropdownlist.Visible = false;

                headTeacherNameLabel.Text = teachersDropdownlist.Text;
            }
            else
            {
                RadMessageBox.Show("Трябва да изберете учител от списъка!", "Грешка!");
            }
        }

        private void finishButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            mToCloseTheForm = true;

            checkFieldsAndAddOrEditClassInTheDB();

            if (mToCloseTheForm)
            {
                this.Close();
            }
        }

        bool mToCloseTheForm;

        private void checkFieldsAndAddOrEditClassInTheDB()
        {
            int grade = -1;
            string name;
            string shortName;
            long headTeacherID = -1;
            Color color;
            try
            {

                grade = (int)gradeDropdownlist.SelectedItem.Value;

                name = nameTextbox.Text;
                shortName = shortNameTextbox.Text;

                headTeacherID = (long)teachersDropdownlist.SelectedItem.Value;

                color = colorPanel.BackColor;


                #region Checking the inputed data

                int blankChars = 0;
                foreach (char ch in Name)
                {
                    if (ch == ' ') blankChars++;
                }

                if (Name == "" || blankChars == Name.Length)
                {
                    RadMessageBox.Show("Моля,  въведете име на класа", "Грешка!");
                    mToCloseTheForm = false;
                    return;
                }
                #endregion



                if (mFormState == FormState.AddingNew)
                {
                    try
                    {
                        mDBManager.Classes.Add(
                            new Class(name, shortName, grade, color, headTeacherID)
                        );
                    }
                    catch { }
                }

                else
                {
                    int i = 0;
                    foreach(Class cl in mDBManager.Classes)
                    {
                        if (mID == cl.ID)
                        {
                            mDBManager.Classes[i].Name = name;
                            mDBManager.Classes[i].ShortName = shortName;
                            mDBManager.Classes[i].Color = color;
                            mDBManager.Classes[i].HeadTeacherID = headTeacherID;
                            mDBManager.Classes[i].Grade = grade;
                            return;
                        }
                        i++;
                    }
                }
            }

            catch (NullReferenceException)
            {
                RadMessageBox.Show("Моля,  въведете коректни и пълни данни", "Грешка");
                mToCloseTheForm = false;
            }
        }
    }
}
