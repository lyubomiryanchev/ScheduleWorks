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
using Telerik.WinControls.UI;

namespace ScheduleWorks.UI
{
    public partial class AddOrEditLessonForm : Telerik.WinControls.UI.RadForm
    {
        private DBManager mDBManager;
        private FormState mFormState;
        private Curriculum mLesson;
        private int mID;
        private bool toCloseTheForm;

        public AddOrEditLessonForm(DBManager aDBManager, int aID)
        {
            InitializeComponent();

            mFormState = FormState.Editing;
            mDBManager = aDBManager;
            mID = aID;
            this.Text = FormTitles.LessonForm.Edit;

            foreach (var l in mDBManager.Lessons)
            {
                if (l.ID == aID)
                {
                    mLesson = l;
                    break;
                }
            }

            addDefaultControlsInformationWhenEditing();
        }

        public AddOrEditLessonForm(DBManager aDBManager)
        {
            InitializeComponent();

            mFormState = FormState.AddingNew;
            mDBManager = aDBManager;
            this.Text = FormTitles.LessonForm.Add;

            addDefaultControlsInformationWhenAddingNew();
        }

        #region Default Information for the controls

        private void addDefaultControlsInformationWhenEditing()
        {
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            radListDataItem4.Text = "1 час";
            radListDataItem4.Value = 1;
            radListDataItem4.TextWrap = true;
            radListDataItem5.Text = "2 часа";
            radListDataItem5.Value = 2;
            radListDataItem5.TextWrap = true;
            radListDataItem6.Text = "без значение";
            radListDataItem6.Value = 3;
            radListDataItem6.TextWrap = true;
            try
            {
                switch (mLesson.HourLenght)
                {
                    case HourLenght.SingleHour:
                        radListDataItem4.Selected = true;
                        break;
                    case HourLenght.DoubleHour:
                        radListDataItem5.Selected = true;
                        break;
                    case HourLenght.NoMatter:
                        radListDataItem6.Selected = true;
                        break;

                }
            }
            catch
            {
                radListDataItem4.Selected = true;
            }
            this.dropDownListLessonLenght.Items.Add(radListDataItem4);
            this.dropDownListLessonLenght.Items.Add(radListDataItem5);
            this.dropDownListLessonLenght.Items.Add(radListDataItem6);

            foreach (Teacher t in mDBManager.Teachers)
            {
                RadListDataItem listDataItem = new RadListDataItem();
                listDataItem.Text = t.Name;
                listDataItem.Value = t.ID;

                if (t.ID == mLesson.Teacher.ID)
                {
                    listDataItem.Selected = true;
                }

                dropDownListTeachers.Items.Add(listDataItem);
            }

            foreach (Subject s in mDBManager.Subjects)
            {
                RadListDataItem listDataItem = new RadListDataItem();
                listDataItem.Text = s.Name;
                listDataItem.Value = s.ID;

                if (s.ID == mLesson.Subject.ID)
                {
                    listDataItem.Selected = true;
                }

                dropDownListSubjects.Items.Add(listDataItem);
            }

            foreach (Class c in mDBManager.Classes)
            {
                RadListDataItem listDataItem = new RadListDataItem();
                listDataItem.Text = c.Name;
                listDataItem.Value = c.ID;

                if (c.ID == mLesson.Class.ID)
                {
                    listDataItem.Selected = true;
                }

                dropDownListClasses.Items.Add(listDataItem);
            }

            foreach (Classroom c in mDBManager.Classrooms)
            {
                RadListDataItem listDataItem = new RadListDataItem();
                listDataItem.Text = c.Name;
                listDataItem.Value = c.ID;

                try
                {
                    if (c.ID == mLesson.DesiredClassroom.ID)
                    {
                        listDataItem.Selected = true;
                    }
                }
                catch { }

                dropDownListWantedRoom.Items.Add(listDataItem);
            }

            spinEditorHoursPerWeek.Value = mLesson.HoursPerWeek;
        }
        private void addDefaultControlsInformationWhenAddingNew()
        {
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            radListDataItem4.Text = "1 час";
            radListDataItem4.Value = 1;
            radListDataItem4.TextWrap = true;
            radListDataItem5.Text = "2 часа";
            radListDataItem5.Value = 2;
            radListDataItem5.TextWrap = true;
            radListDataItem6.Text = "без значение";
            radListDataItem6.Value = 3;
            radListDataItem6.TextWrap = true;
            this.dropDownListLessonLenght.Items.Add(radListDataItem4);
            this.dropDownListLessonLenght.Items.Add(radListDataItem5);
            this.dropDownListLessonLenght.Items.Add(radListDataItem6);



            foreach (Teacher t in mDBManager.Teachers)
            {
                RadListDataItem listDataItem = new RadListDataItem();
                listDataItem.Text = t.Name;
                listDataItem.Value = t.ID;

                dropDownListTeachers.Items.Add(listDataItem);
            }

            foreach (Subject s in mDBManager.Subjects)
            {
                RadListDataItem listDataItem = new RadListDataItem();
                listDataItem.Text = s.Name;
                listDataItem.Value = s.ID;

                dropDownListSubjects.Items.Add(listDataItem);
            }

            foreach (Class c in mDBManager.Classes)
            {
                RadListDataItem listDataItem = new RadListDataItem();
                listDataItem.Text = c.Name;
                listDataItem.Value = c.ID;

                dropDownListClasses.Items.Add(listDataItem);
            }

            foreach (Classroom c in mDBManager.Classrooms)
            {
                RadListDataItem listDataItem = new RadListDataItem();
                listDataItem.Text = c.Name;
                listDataItem.Value = c.ID;

                dropDownListWantedRoom.Items.Add(listDataItem);
            }
        }

        #endregion 

        private void checkFieldsAndAddOrEditInTheDB()
        {
            
            long teacherID;
            int subjectID;
            long classID;
            int classroomID;
            HourLenght hourLenght = HourLenght.NoMatter;

            Teacher teacher;
            Subject subject;
            Class class1;
            Classroom classroom;

            #region Reading fields from the form
            try
            {
                long.TryParse(dropDownListTeachers.SelectedValue.ToString(), out teacherID);
                int.TryParse(dropDownListSubjects.SelectedValue.ToString(), out subjectID);
                long.TryParse(dropDownListClasses.SelectedValue.ToString(), out classID);
                int.TryParse(dropDownListWantedRoom.SelectedValue.ToString(), out classroomID);
            }
            catch
            {
                RadMessageBox.Show("Моля, въведете коректни данни!", "Грешка!");
                toCloseTheForm = false;
                return;
            }

                switch (int.Parse(dropDownListLessonLenght.SelectedItem.Value.ToString()))
                {
                    case 1:
                        hourLenght = HourLenght.SingleHour;
                        break;
                    case 2:
                        hourLenght = HourLenght.DoubleHour;
                        break;
                    case 3:
                        hourLenght = HourLenght.NoMatter;
                        break;
                }

                var t1 = from t in mDBManager.Teachers
                         where t.ID == teacherID
                         select t;
                teacher = t1.FirstOrDefault();

                var s1 = from s in mDBManager.Subjects
                         where s.ID == subjectID
                         select s;
                subject = s1.FirstOrDefault();

                var c1 = from c in mDBManager.Classes
                         where c.ID == classID
                         select c;
                class1 = c1.FirstOrDefault();

                var cl1 = from cl in mDBManager.Classrooms
                          where cl.ID == classroomID
                          select cl;
                classroom = cl1.FirstOrDefault();

            #endregion

            try
            {
                if (mFormState == FormState.AddingNew)
                {
                    bool exThrown = false;
                    try{
                        if (mLesson.AlternativeClassrooms.Count != 0)
                        {
                            mDBManager.Lessons.Add(new Curriculum(teacher, subject, class1, classroom, mLesson.AlternativeClassrooms, hourLenght, (int)spinEditorHoursPerWeek.Value));
                        }
                    }
                    catch{
                        exThrown = true;
                    }
                    if (exThrown)
                    {
                        mDBManager.Lessons.Add(new Curriculum(teacher, subject, class1, classroom, hourLenght, (int)spinEditorHoursPerWeek.Value));
                    }
                }

                else if(mFormState == FormState.Editing)
                {
                    int i = 0;
                    foreach (Curriculum l in mDBManager.Lessons)
                    {
                        if (l.ID == mID)
                        {
                            mDBManager.Lessons[i].Teacher = teacher;
                            mDBManager.Lessons[i].Subject = subject;
                            mDBManager.Lessons[i].Class = class1;
                            mDBManager.Lessons[i].DesiredClassroom = classroom;
                            mDBManager.Lessons[i].HourLenght = hourLenght;
                            mDBManager.Lessons[i].HoursPerWeek = (int)spinEditorHoursPerWeek.Value;
                            mDBManager.Lessons[i].AlternativeClassrooms = mLesson.AlternativeClassrooms;
                        }
                        i++;
                    }
                }

            }
            catch(Exception e)
            {
                RadMessageBox.Show("Моля, въведете информация за всички полета! " + e.Message, "Грешка");
                toCloseTheForm = false;
            }
        }

        private void buttonReadyClick(object sender, EventArgs e)
        {
            toCloseTheForm = true;

            checkFieldsAndAddOrEditInTheDB();

            if (toCloseTheForm)
            {
                this.Close();
            }
        }


        ChooseItemsForm chooseAlternativeClassroomsForm;
        private void addAlternativeClassroomsButton_Click(object sender, EventArgs e)
        {
            List<ChooseItemsParameters> classrooms = new List<ChooseItemsParameters>();
            List<ChooseItemsParameters> alreadySelectedClassrooms = new List<ChooseItemsParameters>();
            foreach (var classroom in mDBManager.Classrooms)
            {
                if (long.Parse(dropDownListWantedRoom.SelectedValue.ToString()) != classroom.ID)
                {
                    classrooms.Add(new ChooseItemsParameters(classroom.Name, classroom.ShortName, classroom.ID));
                }
            }

            if (mFormState == FormState.AddingNew)
            {
                chooseAlternativeClassroomsForm = new ChooseItemsForm(ChooseItems.Mode.MultipleItems, "Избери алтернативни стаи за този урок", classrooms);
            }

            if(mFormState == FormState.Editing){
                foreach(var room in mLesson.AlternativeClassrooms){
                    alreadySelectedClassrooms.Add(new ChooseItemsParameters(room.Name, room.ShortName, room.ID));
                }

                chooseAlternativeClassroomsForm = new ChooseItemsForm(ChooseItems.Mode.MultipleItems, "Редактирай алтернативните стаи за този урок", classrooms, alreadySelectedClassrooms);
            }

            chooseAlternativeClassroomsForm.OnReadyButtonClicked += chooseAlternativeClassroomsForm_OnReadyButtonClicked;
            chooseAlternativeClassroomsForm.Show();
        }

        void chooseAlternativeClassroomsForm_OnReadyButtonClicked(object sender, EventArgs e)
        {
            mLesson.AlternativeClassrooms.Clear();
            foreach(var i in chooseAlternativeClassroomsForm.GetSelectedItems()){
                foreach (var room in mDBManager.Classrooms)
                {
                    if (int.Parse(i.ToString()) == room.ID)
                    {
                        mLesson.AlternativeClassrooms.Add(room);
                    }
                }
            }
        }
    }
}
