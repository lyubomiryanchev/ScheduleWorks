using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using ScheduleWorks.Utility;

namespace ScheduleWorks.UI
{
    public partial class EditParametersForm : Telerik.WinControls.UI.RadForm
    {
        DBManager mDBManager;

        List<Control[]> ControlGroups = new List<Control[]>();

        public EditParametersForm(DBManager aDBManager)
        {
            InitializeComponent();
            mDBManager = aDBManager;
            if (mDBManager.AlgorithmParameters == null)
            {
                mDBManager.AlgorithmParameters = new AlgorithmParameters();
            }

            ControlGroups.Add(new Control[] { firstLow, firstMedium, firstHigh});
            ControlGroups.Add(new Control[] { secondLow, secondMedium, secondHigh });
            ControlGroups.Add(new Control[] { thirdLow, thirdMedium, thirdHigh });
            ControlGroups.Add(new Control[] { fourthLow, fourthMedium, fourthHigh });
            ControlGroups.Add(new Control[] { fifthLow, fifthMedium, fifthHigh });
            ControlGroups.Add(new Control[] { sixthLow, sixthMedium, sixthHigh });
            ControlGroups.Add(new Control[] { seventhLow, seventhMedium, seventhHigh });

            for (int i = 0; i < 7; i++)
            {
                foreach (var item in ControlGroups[i])
                {
                    item.Enabled = false;
                }
            }
        }


        int CurrentHoursPerDay;

        void EnableControlsTo(int toControl)
        {
            CurrentHoursPerDay = toControl;
            for (int i = 0; i < toControl; i++)
            {
                foreach (var item in ControlGroups[i])
                {
                    item.Enabled = true;
                }
            }
            for (int i = toControl; i < 7; i++)
            {
                foreach (var item in ControlGroups[i])
                {
                    item.Enabled = false;
                }
            }
        }

        void LoadParametersToCheckboxes(AlgorithmParameters param, int numberOfHours)
        {
            try
            {
                if (numberOfHours == 4)
                {
                    foreach (var p in param.FourHoursPerDay)
                    {
                        int row = 0;
                        foreach (var diff in param.FourHoursPerDay)
                        {
                            SetControlsChecked(row, diff);
                            row++;
                        }

                    }
                }
                if (numberOfHours == 5)
                {
                    foreach (var p in param.FiveHoursPerDay)
                    {
                        int row = 0;
                        foreach (var diff in param.FiveHoursPerDay)
                        {
                            SetControlsChecked(row, diff);
                            row++;
                        }
                    }
                }
                if (numberOfHours == 6)
                {
                    foreach (var p in param.FourHoursPerDay)
                    {
                        int row = 0;
                        foreach (var diff in param.SixHoursPerDay)
                        {
                            SetControlsChecked(row, diff);
                            row++;
                        }
                    }
                }
                if (numberOfHours == 7)
                {
                    int row = 0;
                    foreach (var diff in param.SevenHoursPerDay)
                    {
                        SetControlsChecked(row, diff);
                        row++;
                    }
                }
            }
            catch { }
        }

        void SetControlsChecked(int rowIndex, RelativeSubjectDifficulty diff)
        {
            if ((diff & RelativeSubjectDifficulty.Low) == RelativeSubjectDifficulty.Low)
            {
                (ControlGroups[rowIndex][0] as RadCheckBox).Checked = true;
            }
            if ((diff & RelativeSubjectDifficulty.Normal) == RelativeSubjectDifficulty.Normal)
            {
                (ControlGroups[rowIndex][1] as RadCheckBox).Checked = true;
            }
            if ((diff & RelativeSubjectDifficulty.High) == RelativeSubjectDifficulty.High)
            {
                (ControlGroups[rowIndex][2]as RadCheckBox).Checked = true;
            }
        }

        void ResetCheckBoxes()
        {
            foreach (var c in ControlGroups)
            {
                foreach (var control in c)
                {
                    (control as RadCheckBox).Checked = false;
                }
            }
        }

        bool firstTimeFour = true;
        private void buttonFourHours_Click(object sender, EventArgs e)
        {
            if (firstTimeFour)
            {
                firstTimeFour = false;
                GoThroughAllCheckboxesAndSetDBManager();
            }
            GoThroughAllCheckboxesAndSetDBManager();
            EnableControlsTo(4);
            ResetCheckBoxes();
            LoadParametersToCheckboxes(mDBManager.AlgorithmParameters, 4);
        }

        bool firstTimeFive = true;
        private void buttonFiveHours_Click(object sender, EventArgs e)
        {
            if (firstTimeFive)
            {
                firstTimeFive = false;
                GoThroughAllCheckboxesAndSetDBManager();
            }
            GoThroughAllCheckboxesAndSetDBManager();
            EnableControlsTo(5);
            ResetCheckBoxes();
            LoadParametersToCheckboxes(mDBManager.AlgorithmParameters, 5);
        }

        bool firstTimeSix = true;
        private void buttonSixHours_Click(object sender, EventArgs e)
        {
            if (firstTimeSix)
            {
                firstTimeSix = false;
                GoThroughAllCheckboxesAndSetDBManager();
            }
            GoThroughAllCheckboxesAndSetDBManager();
            EnableControlsTo(6);
            ResetCheckBoxes();
            LoadParametersToCheckboxes(mDBManager.AlgorithmParameters, 6);
        }

        bool firstTimeSeven = true;
        private void buttonSevenHours_Click(object sender, EventArgs e)
        {
            if(firstTimeSeven)
            {
                firstTimeSeven = false;
                GoThroughAllCheckboxesAndSetDBManager();
            }
            EnableControlsTo(7);
            ResetCheckBoxes();
            LoadParametersToCheckboxes(mDBManager.AlgorithmParameters, 7);
        }

        void GoThroughAllCheckboxesAndSetDBManager()
        {
            bool toRemoveNone = false;
            RelativeSubjectDifficulty firstHour = RelativeSubjectDifficulty.None;
            if (firstLow.Checked)
            {
                firstHour |= RelativeSubjectDifficulty.Low;
                toRemoveNone = true;
            }
            if (firstMedium.Checked)
            {
                firstHour |= RelativeSubjectDifficulty.Normal;
                toRemoveNone = true;
            }
            if (firstHigh.Checked)
            {
                firstHour |= RelativeSubjectDifficulty.High;
                toRemoveNone = true;
            }
            if (toRemoveNone)
            {
                firstHour ^= RelativeSubjectDifficulty.None;
            }

            RelativeSubjectDifficulty secondHour = RelativeSubjectDifficulty.None;
            toRemoveNone = false;
            if (secondLow.Checked)
            {
                secondHour |= RelativeSubjectDifficulty.Low;
                toRemoveNone = true;
            }
            if (secondMedium.Checked)
            {
                secondHour |= RelativeSubjectDifficulty.Normal;
                toRemoveNone = true;
            }
            if (secondHigh.Checked)
            {
                secondHour |= RelativeSubjectDifficulty.High;
                toRemoveNone = true;
            }
            if (toRemoveNone)
            {
                secondHour ^= RelativeSubjectDifficulty.None;
            }

            RelativeSubjectDifficulty thirdHour = RelativeSubjectDifficulty.None;
            toRemoveNone = false;
            if (thirdLow.Checked)
            {
                thirdHour |= RelativeSubjectDifficulty.Low;
                toRemoveNone = true;
            }
            if (thirdMedium.Checked)
            {
                thirdHour |= RelativeSubjectDifficulty.Normal;
                toRemoveNone = true;
            }
            if (thirdHigh.Checked)
            {
                thirdHour |= RelativeSubjectDifficulty.High;
                toRemoveNone = true;
            }
            if (toRemoveNone)
            {
                thirdHour ^= RelativeSubjectDifficulty.None;
            }

            RelativeSubjectDifficulty fourthHour = RelativeSubjectDifficulty.None;
            toRemoveNone = false;
            if (fourthLow.Checked)
            {
                fourthHour |= RelativeSubjectDifficulty.Low;
                toRemoveNone = true;
            }
            if (fourthMedium.Checked)
            {
                fourthHour |= RelativeSubjectDifficulty.Normal;
                toRemoveNone = true;
            }
            if (fourthHigh.Checked)
            {
                fourthHour |= RelativeSubjectDifficulty.High;
                toRemoveNone = true;
            }
            if (toRemoveNone)
            {
                fourthHour ^= RelativeSubjectDifficulty.None;
            }

            RelativeSubjectDifficulty fifthHour = RelativeSubjectDifficulty.None;
            toRemoveNone = false;
            if (fifthLow.Checked)
            {
                fifthHour |= RelativeSubjectDifficulty.Low;
                toRemoveNone = true;
            }
            if (fifthMedium.Checked)
            {
                fifthHour |= RelativeSubjectDifficulty.Normal;
                toRemoveNone = true;
            }
            if (fifthHigh.Checked)
            {
                fifthHour |= RelativeSubjectDifficulty.High;
                toRemoveNone = true;
            }
            if (toRemoveNone)
            {
                fifthHour ^= RelativeSubjectDifficulty.None;
            }

            RelativeSubjectDifficulty sixthHour = RelativeSubjectDifficulty.None;
            toRemoveNone = false;
            if (sixthLow.Checked)
            {
                sixthHour |= RelativeSubjectDifficulty.Low;
                toRemoveNone = true;
            }
            if (sixthMedium.Checked)
            {
                sixthHour |= RelativeSubjectDifficulty.Normal;
                toRemoveNone = true;
            }
            if (sixthHigh.Checked)
            {
                sixthHour |= RelativeSubjectDifficulty.High;
                toRemoveNone = true;
            }
            if (toRemoveNone)
            {
                sixthHour ^= RelativeSubjectDifficulty.None;
            }

            RelativeSubjectDifficulty seventhHour = RelativeSubjectDifficulty.None;
            toRemoveNone = false;
            if (seventhLow.Checked)
            {
                seventhHour |= RelativeSubjectDifficulty.Low;
                toRemoveNone = true;
            }
            if (seventhMedium.Checked)
            {
                seventhHour |= RelativeSubjectDifficulty.Normal;
                toRemoveNone = true;
            }
            if (seventhHigh.Checked)
            {
                seventhHour |= RelativeSubjectDifficulty.High;
                toRemoveNone = true;
            }
            if (toRemoveNone)
            {
                seventhHour ^= RelativeSubjectDifficulty.None;
            }


            if (CurrentHoursPerDay == 4)
            {
                mDBManager.AlgorithmParameters.FourHoursPerDay[0] = firstHour;
                mDBManager.AlgorithmParameters.FourHoursPerDay[1] = secondHour;
                mDBManager.AlgorithmParameters.FourHoursPerDay[2] = thirdHour;
                mDBManager.AlgorithmParameters.FourHoursPerDay[3] = fourthHour;
            }

            if (CurrentHoursPerDay == 5)
            {
                mDBManager.AlgorithmParameters.FiveHoursPerDay[0] = firstHour;
                mDBManager.AlgorithmParameters.FiveHoursPerDay[1] = secondHour;
                mDBManager.AlgorithmParameters.FiveHoursPerDay[2] = thirdHour;
                mDBManager.AlgorithmParameters.FiveHoursPerDay[3] = fourthHour;
                mDBManager.AlgorithmParameters.FiveHoursPerDay[4] = fifthHour;
            }

            if (CurrentHoursPerDay == 6)
            {
                mDBManager.AlgorithmParameters.SixHoursPerDay[0] = firstHour;
                mDBManager.AlgorithmParameters.SixHoursPerDay[1] = secondHour;
                mDBManager.AlgorithmParameters.SixHoursPerDay[2] = thirdHour;
                mDBManager.AlgorithmParameters.SixHoursPerDay[3] = fourthHour;
                mDBManager.AlgorithmParameters.SixHoursPerDay[4] = fifthHour;
                mDBManager.AlgorithmParameters.SixHoursPerDay[5] = sixthHour;
            }

            if (CurrentHoursPerDay == 7)
            {
                mDBManager.AlgorithmParameters.SevenHoursPerDay[0] = firstHour;
                mDBManager.AlgorithmParameters.SevenHoursPerDay[1] = secondHour;
                mDBManager.AlgorithmParameters.SevenHoursPerDay[2] = thirdHour;
                mDBManager.AlgorithmParameters.SevenHoursPerDay[3] = fourthHour;
                mDBManager.AlgorithmParameters.SevenHoursPerDay[4] = fifthHour;
                mDBManager.AlgorithmParameters.SevenHoursPerDay[5] = sixthHour;
                mDBManager.AlgorithmParameters.SevenHoursPerDay[6] = seventhHour;
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            GoThroughAllCheckboxesAndSetDBManager();
            this.Close();
        }
    }
}

