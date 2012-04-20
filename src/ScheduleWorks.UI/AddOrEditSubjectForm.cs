using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ScheduleWorks.Utility;

namespace ScheduleWorks.UI
{
    public partial class AddOrEditSubjectForm : Telerik.WinControls.UI.RadForm
    {
        DBManager mDBManager;
        FormState mFormState;
        bool mToCloseTheForm;
        Subject mSubject;
        long mID;
       

        public AddOrEditSubjectForm(DBManager aDBManager)
        {
            InitializeComponent();

            mDBManager = aDBManager;
            mFormState = FormState.AddingNew;
            this.Text = FormTitles.SubjectForm.Add;

            barComplexity.Maximum = 3;
            barComplexity.Minimum = 1;
            barComplexity.TickFrequency = 1;

            groupboxColorPanelColor.BackColor = RandomColor.GetRandomColor();
        }

        public AddOrEditSubjectForm(DBManager aDBManager, long aID)
        {
            InitializeComponent();

            mDBManager = aDBManager;
            mID = aID;
            mFormState = FormState.Editing;
            this.Text = FormTitles.SubjectForm.Edit;

            foreach (var subject in mDBManager.Subjects)
            {
                if (subject.ID == aID)
                {
                    mSubject = subject;
                    break;
                }
            }


            textboxName.Text = mSubject.Name;
            textboxShortName.Text = mSubject.ShortName;

            if (mSubject.Color != Color.Empty)
            {
                groupboxColorPanelColor.BackColor = mSubject.Color;
            }
            else
            {
                groupboxColorPanelColor.BackColor = RandomColor.GetRandomColor();
            }

            switch (mSubject.Difficulty)
            {
                case RelativeSubjectDifficulty.Low:
                    barComplexity.Value = 1;
                    break;
                case RelativeSubjectDifficulty.Normal:
                    barComplexity.Value = 2;
                    break;
                case RelativeSubjectDifficulty.High:
                    barComplexity.Value = 3;
                    break;
            }

            barComplexity.Maximum = 3;
            barComplexity.Minimum = 1;
            barComplexity.TickFrequency = 1;
        }

        private void textboxNameTextChanged(object sender, EventArgs e)
        {
            int lettersToBeCopied = 2;
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

        private void checkFieldsAndAddOrEditInTheDB()
        {

            string name = textboxName.Text;
            string shortName = textboxShortName.Text;
            Color color = groupboxColorPanelColor.BackColor;
            RelativeSubjectDifficulty relativeDiff = RelativeSubjectDifficulty.Normal;



            switch (barComplexity.Value)
            {
                case 1:
                    relativeDiff = RelativeSubjectDifficulty.Low;
                    break;

                case 2:
                    relativeDiff = RelativeSubjectDifficulty.Normal;
                    break;

                case 3:
                    relativeDiff = RelativeSubjectDifficulty.High;
                    break;
            }

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

            if (mFormState == FormState.Editing)
            {
                int i = 0;
                foreach (Subject s in mDBManager.Subjects)
                {
                    if (mID == s.ID)
                    {
                        mDBManager.Subjects[i].Name = name;
                        mDBManager.Subjects[i].ShortName = shortName;
                        mDBManager.Subjects[i].Color = color;
                        mDBManager.Subjects[i].Difficulty = relativeDiff;
                        
                        return;
                    }
                    i++;
                }
            }

            else
            {
                mDBManager.Subjects.Add(new Subject(name, shortName, color, relativeDiff));
            }

        }

        private void buttonFinishClick(object sender, EventArgs e)
        {
            mToCloseTheForm = true;

            checkFieldsAndAddOrEditInTheDB();

            if (mToCloseTheForm)
            {
                this.Close();
            }
        }
    }
}
