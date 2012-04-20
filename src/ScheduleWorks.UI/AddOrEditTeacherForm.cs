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
using ScheduleWorks.Utility;

namespace ScheduleWorks.UI
{
    public partial class AddOrEditTeacherForm : Telerik.WinControls.UI.RadForm
    {
        private DBManager mDBManager;
        private Teacher mTeacher;
        private FormState mFormState;
        private bool mToCloseTheForm = true;
        private long mID;

        public AddOrEditTeacherForm(DBManager aDBManager)
        {
            InitializeComponent();

            mDBManager = aDBManager;
            mFormState = FormState.AddingNew;
            this.Text = FormTitles.TacherForm.Add;

            radioButtonFemale.IsChecked = true;

            groupboxColorPanelColor.BackColor = RandomColor.GetRandomColor();
        }

        public AddOrEditTeacherForm(DBManager aDBManager, long aID)
        {
            InitializeComponent();

            mDBManager = aDBManager; 
            mID = aID;

            var teach = from t in mDBManager.Teachers
                     where t.ID == aID
                     select t;

            mTeacher = teach.FirstOrDefault();
            
            mFormState = FormState.Editing;
            this.Text = FormTitles.TacherForm.Edit;

            textboxName.Text = mTeacher.Name;
            textboxShortName.Text = mTeacher.ShortName;

            switch (mTeacher.Gender)
            {
                case Gender.Female:
                    radioButtonFemale.IsChecked = true;
                    break;
                case Gender.Male:
                    radioButtonMale.IsChecked = true;
                    break;
            }

            if (mTeacher.Color != Color.Empty)
            {
                groupboxColorPanelColor.BackColor = mTeacher.Color;
            }
            else
            {
                groupboxColorPanelColor.BackColor = RandomColor.GetRandomColor();
            }

        }

        private void textboxNameTextChanged(object sender, EventArgs e)
        {
            int lettersToBeCopied = 3;
            #region Text manipulation
            if (textboxName.Text.Length != 0)
            {
                if (textboxName.Text.Length <= lettersToBeCopied)
                {
                    textboxShortName.Text = textboxName.Text;
                }
                else
                {
                    textboxShortName.Text = textboxName.Text.Substring(0, lettersToBeCopied);
                }
            }
            else
            {
                textboxShortName.Text = "";
            }
            #endregion
        }

        private void groupboxColorButtonChangeColorClick(object sender, EventArgs e)
        {
            RadColorDialog colorDialog = new RadColorDialog();
            colorDialog.SelectedColor = groupboxColorPanelColor.BackColor;
            colorDialog.ShowDialog();
            groupboxColorPanelColor.BackColor = colorDialog.SelectedColor;
        }


        private void CheckFieldsAndAddOrEditInTheDB()
        {
            string name = textboxName.Text;
            string shortName = textboxShortName.Text;

            Gender gender = Gender.Male;
            if (radioButtonFemale.IsChecked) gender = Gender.Female;

            Color color = groupboxColorPanelColor.BackColor;

            #region Field checking
            int blankChars = 0;
            foreach (char ch in name)
            {
                if (ch == ' ') blankChars++;
            }

            if (name == "" || blankChars == name.Length)
            {
                RadMessageBox.Show("Моля, въведете име на класа", "Грешка!");
                mToCloseTheForm = false;
                return;
            }

            #endregion

            if (mFormState == FormState.AddingNew)
            {
                mDBManager.Teachers.Add(new Teacher(name, shortName, color, gender));
            }

            else
            {
                int i = 0;
                foreach (Teacher t in mDBManager.Teachers)
                {
                    if (mID == t.ID)
                    {
                        mDBManager.Teachers[i].Name = name;
                        mDBManager.Teachers[i].ShortName = shortName;
                        mDBManager.Teachers[i].Color = color;
                        mDBManager.Teachers[i].Gender = gender;
                        
                        return;
                    }
                    i++;
                }
            }

        }

        private void buttonFinishClick(object sender, EventArgs e)
        {
            mToCloseTheForm = true;
            CheckFieldsAndAddOrEditInTheDB();

            if (mToCloseTheForm)
            {
                this.Close();
            }
        }
    }
}
