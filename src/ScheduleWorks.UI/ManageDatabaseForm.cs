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
    public partial class ManageDatabaseForm : Telerik.WinControls.UI.RadForm
    {
        public DBManager mDBManager;

        public ManageDatabaseForm(DBManager aDBManager)
        {
            mDBManager = aDBManager;
            InitializeComponent();

            this.Text = "Менажирай базата данни";

            gridViewClasses.AllowAddNewRow = false;
            gridViewClasses.AllowEditRow = false;
            gridViewClasses.AllowDeleteRow = false;
            gridViewClasses.AllowDragToGroup = false;
            gridViewClasses.AllowRowReorder = false;
            gridViewClasses.AllowRowResize = false;
            gridViewClasses.EnableSorting = true;
            gridViewClasses.ShowGroupPanel = false;
            gridViewClasses.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewClasses.ShowColumnHeaders = true;
            gridViewClasses.AllowColumnHeaderContextMenu = true;
            gridViewClasses.ShowRowHeaderColumn = false;
            //gridViewClasses.Columns["Name"].Width = 100;
            //gridViewClasses.Columns["AllowFreeHours"].Width = 80;
            //gridViewClasses.Columns["AllowZeroHours"].Width = 80;
            

            gridViewTeachers.AllowAddNewRow = false;
            gridViewTeachers.AllowEditRow = false;
            gridViewTeachers.AllowDeleteRow = false;
            gridViewTeachers.AllowDragToGroup = false;
            gridViewTeachers.AllowRowReorder = false;
            gridViewTeachers.AllowRowResize = false;
            gridViewTeachers.EnableSorting = true;
            gridViewTeachers.ShowGroupPanel = false;
            gridViewTeachers.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTeachers.ShowRowHeaderColumn = false;
            //gridViewTeachers.Columns["Name"].Width = 100;


            gridViewSubjects.AllowAddNewRow = false;
            gridViewSubjects.AllowEditRow = false;
            gridViewSubjects.AllowDeleteRow = false;
            gridViewSubjects.AllowDragToGroup = false;
            gridViewSubjects.AllowRowReorder = false;
            gridViewSubjects.AllowRowResize = false;
            gridViewSubjects.EnableSorting = true;
            gridViewSubjects.ShowGroupPanel = false;
            gridViewSubjects.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewSubjects.ShowRowHeaderColumn = false;
            //gridViewSubjects.Columns["Name"].Width = 100;

            gridViewClassrooms.AllowAddNewRow = false;
            gridViewClassrooms.AllowEditRow = false;
            gridViewClassrooms.AllowDeleteRow = false;
            gridViewClassrooms.AllowDragToGroup = false;
            gridViewClassrooms.AllowRowReorder = false;
            gridViewClassrooms.AllowRowResize = false;
            gridViewClassrooms.EnableSorting = true;
            gridViewClassrooms.ShowGroupPanel = false;
            gridViewClassrooms.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewClassrooms.ShowRowHeaderColumn = false;
            //gridViewClassrooms.Columns["Name"].Width = 100;

            gridViewLessons.AllowAddNewRow = false;
            gridViewLessons.AllowEditRow = false;
            gridViewLessons.AllowDeleteRow = false;
            gridViewLessons.AllowDragToGroup = false;
            gridViewLessons.AllowRowReorder = false;
            gridViewLessons.AllowRowResize = false;
            gridViewLessons.EnableSorting = true;
            gridViewLessons.ShowGroupPanel = false;
            gridViewLessons.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewLessons.ShowRowHeaderColumn = false;

            
            gridViewClasses.Columns.Add("Име");
            gridViewClasses.Columns.Add("Съкращение");
            gridViewClasses.Columns.Add("Клас");
            gridViewClasses.Columns.Add("Цвят");

            int i = 0;
            foreach(var cl in mDBManager.Classes)
            {
                gridViewClasses.Rows.Add(cl.Name, cl.ShortName, cl.Grade, "██");
                gridViewClasses.Rows[i].Cells[3].Style.ForeColor = cl.Color;
                gridViewClasses.Columns[3].TextAlignment = ContentAlignment.BottomCenter;
                gridViewClasses.Rows[i].Tag = cl.ID;
                i++;
            }


            gridViewTeachers.Columns.Add("Име");
            gridViewTeachers.Columns.Add("Съкращение");
            gridViewTeachers.Columns.Add("Цвят");
            gridViewTeachers.Columns.Add("Пол");

            i = 0;
            foreach (var t in mDBManager.Teachers)
            {   
                string g = "мъж";
                if (t.Gender == Gender.Female) g = "жена";
                gridViewTeachers.Rows.Add(t.Name, t.ShortName, "██", g);
                gridViewTeachers.Rows[i].Cells[2].Style.ForeColor = t.Color;
                gridViewTeachers.Columns[2].TextAlignment = ContentAlignment.BottomCenter;
                gridViewTeachers.Rows[i].Tag = t.ID;
                i++;
            }

            gridViewSubjects.Columns.Add("Име");
            gridViewSubjects.Columns.Add("Съкращение");
            gridViewSubjects.Columns.Add("Цвят");
            gridViewSubjects.Columns.Add("Трудност");

            i = 0;
            foreach (var s in mDBManager.Subjects)
            {
                string d = "ниска";
                if (s.Difficulty == RelativeSubjectDifficulty.Normal) d = "средна";
                else if (s.Difficulty == RelativeSubjectDifficulty.High) d = "висока";
                gridViewSubjects.Rows.Add(s.Name, s.ShortName, "██", d);
                gridViewSubjects.Rows[i].Cells[2].Style.ForeColor = s.Color;
                gridViewSubjects.Columns[2].TextAlignment = ContentAlignment.BottomCenter;
                gridViewSubjects.Rows[i].Tag = s.ID;
                i++;
            }

            gridViewClassrooms.Columns.Add("Име");
            gridViewClassrooms.Columns.Add("Съкращение");
            gridViewClassrooms.Columns.Add("Цвят");
            gridViewClassrooms.Columns.Add("Класна?");
            gridViewClassrooms.Columns.Add("Специализарана?");

            i = 0;
            foreach (var cl in mDBManager.Classrooms)
            {
                string isHome = "Не";
                if (cl.IsHomeClassroom)
                {
                    isHome = "Да";
                }

                string isSpecialisated = "Не";
                if (cl.IsSpecialisated)
                {
                    isSpecialisated = "Да";
                }
                gridViewClassrooms.Rows.Add(cl.Name, cl.ShortName, "██", isHome, isSpecialisated);
                gridViewClassrooms.Rows[i].Cells[2].Style.ForeColor = cl.Color;
                gridViewClassrooms.Columns[2].TextAlignment = ContentAlignment.BottomCenter;
                gridViewClassrooms.Rows[i].Tag = cl.ID;
                i++;
            }

            gridViewLessons.Columns.Add("Предмет");
            gridViewLessons.Columns.Add("Клас");
            gridViewLessons.Columns.Add("Учител");
            gridViewLessons.Columns.Add("Брой часове");
            gridViewLessons.Columns.Add("Тип часове");

            i = 0;
            foreach (var lesson in mDBManager.Lessons)
            {
                string hourlen = "";
                switch(lesson.HourLenght)
                {
                    case HourLenght.DoubleHour:
                        hourlen = "Двоен час"; break;
                    case HourLenght.SingleHour:
                        hourlen = "Единичен час"; break;
                    case HourLenght.NoMatter:
                        hourlen = "Без значение"; break;
                }
                gridViewLessons.Rows.Add(lesson.Subject.Name,
                    lesson.Class.Name,
                    lesson.Teacher.Name,
                    lesson.HoursPerWeek,
                    hourlen);
                gridViewLessons.Rows[i].Tag = lesson.ID;
                i++;
            }
        }

        void openForm(FormTypes formType)
        {
            object Form = new Form();
            switch(formType){
                case FormTypes.AddOrEditClassForm:
                    Form = new AddOrEditClassForm(mDBManager);
                    break;
                case FormTypes.AddOrEditClassroomForm:
                    Form = new AddOrEditClassroomForm(mDBManager); 
                    break;
                case FormTypes.AddOrEditSubjectForm:
                    Form = new AddOrEditSubjectForm(mDBManager);
                    break;
                case FormTypes.AddOrEditTeacherForm:
                    Form = new AddOrEditTeacherForm(mDBManager);
                    break;
                case FormTypes.AddOrEditLessonForm:
                    Form = new AddOrEditLessonForm(mDBManager);
                    break;
            }
            (Form as Form).FormClosed += onSomeFormClosed;
            (Form as Form).Show();
        }

        void openForm(FormTypes formType, long ID)
        {
            if (ID != -1) // -1 indicates that there's no selected row in the current gridview
            { 
                object Form = new Form();
                switch (formType)
                {
                    case FormTypes.EditGroups:
                        Form = new EditGroupsForm(mDBManager, (int)ID);
                        break;
                    case FormTypes.AddOrEditClassForm:
                        Form = new AddOrEditClassForm(mDBManager, (int)ID);
                        break;
                    case FormTypes.AddOrEditClassroomForm:
                        Form = new AddOrEditClassroomForm(mDBManager, ID);
                        break;
                    case FormTypes.AddOrEditSubjectForm:
                        Form = new AddOrEditSubjectForm(mDBManager, ID);
                        break;
                    case FormTypes.AddOrEditTeacherForm:
                        Form = new AddOrEditTeacherForm(mDBManager, ID);
                        break;
                    case FormTypes.AddOrEditLessonForm:
                        Form = new AddOrEditLessonForm(mDBManager, (int)ID);
                        break;
                    case FormTypes.SetTimeoffForm:
                        ObjectType type = ObjectType.Subject;
                        switch (pageviewManageDatabase.SelectedPage.Name)
                        {
                            case "pageSubjects":
                                type = ObjectType.Subject;
                                break;
                            case "pageTeachers":
                                type = ObjectType.Teacher;
                                break;
                            case "pageClasses":
                                type = ObjectType.Class;
                                break;
                            case "pageClassrooms":
                                type = ObjectType.Classroom;
                                break;
                            case "pageLessons":
                                type = ObjectType.Lesson;
                                break;
                        }
                        Form = new SetTimeoffForm(mDBManager, type, ID);
                        break;
                }
                (Form as Form).FormClosed += onSomeFormClosed;
                (Form as Form).Show();
            }
        }

        private void buttonAddClick(object sender, EventArgs e)
        {
            switch(pageviewManageDatabase.SelectedPage.Name){
                case "pageSubjects":
                    openForm(FormTypes.AddOrEditSubjectForm);
                    break;
                case "pageTeachers":
                    openForm(FormTypes.AddOrEditTeacherForm);
                    break;
                case "pageClasses":
                    openForm(FormTypes.AddOrEditClassForm);
                    break;
                case "pageClassrooms":
                    openForm(FormTypes.AddOrEditClassroomForm);
                    break;
                case "pageLessons":
                    openForm(FormTypes.AddOrEditLessonForm);
                    break;
            }
        }

        private void buttonEditClick(object sender, EventArgs e)
        {
            const int noRowSelected = -1;
            switch (pageviewManageDatabase.SelectedPage.Name)
            {
                case "pageSubjects":
                    long ID = noRowSelected;
                    foreach (var row in gridViewSubjects.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.AddOrEditSubjectForm, ID);
                    break;
                case "pageTeachers":
                    long IDt = noRowSelected;
                    foreach (var row in gridViewTeachers.Rows)
                    {
                        if (row.IsSelected)
                        {
                            IDt = (long)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.AddOrEditTeacherForm, IDt);
                    break;
                case "pageClasses":
                    ID = noRowSelected;
                    foreach (var row in gridViewClasses.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.AddOrEditClassForm, ID);
                    break;
                case "pageClassrooms":
                    ID = noRowSelected;
                    foreach (var row in gridViewClassrooms.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.AddOrEditClassroomForm, ID);
                    break;
                case "pageLessons":
                    ID = noRowSelected;
                    foreach (var row in gridViewLessons.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.AddOrEditLessonForm, ID);
                    break;
            }
        }

        private void buttonTimeoffClick(object sender, EventArgs e)
        {
            switch (pageviewManageDatabase.SelectedPage.Name)
            {
                case "pageSubjects":
                    long ID = 0;
                    foreach (var row in gridViewSubjects.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.SetTimeoffForm, ID);
                    break;
                case "pageTeachers":
                    long IDt = 0;
                    foreach (var row in gridViewTeachers.Rows)
                    {
                        if (row.IsSelected)
                        {
                            IDt = (long)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.SetTimeoffForm, IDt);
                    break;
                case "pageClasses":
                    ID = 0;
                    foreach (var row in gridViewClasses.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.SetTimeoffForm, ID);
                    break;
                case "pageClassrooms":
                    ID = 0;
                    foreach (var row in gridViewClassrooms.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.SetTimeoffForm, ID);
                    break;
                case "pageLessons":
                    ID = 0;
                    foreach (var row in gridViewLessons.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    openForm(FormTypes.SetTimeoffForm, ID);
                    break;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            switch (pageviewManageDatabase.SelectedPage.Name)
            {
                case "pageSubjects":
                    long ID = -1;
                    foreach (var row in gridViewSubjects.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    if (ID != -1)
                    {
                        foreach (Subject s in mDBManager.Subjects)
                        {
                            if (s.ID == ID)
                            {
                                mDBManager.Subjects.Remove(s);
                                break;
                            }
                        }
                    }
                    onSomeFormClosed("SubjectForm", EventArgs.Empty);
                    break;
                case "pageTeachers":
                    long IDt = -1;
                    foreach (var row in gridViewTeachers.Rows)
                    {
                        if (row.IsSelected)
                        {
                            IDt = (long)row.Tag;
                            break;
                        }
                    }
                    if (IDt != -1)
                    {
                        foreach (var s in mDBManager.Teachers)
                        {
                            if (s.ID == IDt)
                            {
                                mDBManager.Teachers.Remove(s);
                                break;
                            }
                        }
                    }
                    onSomeFormClosed("TeacherForm", EventArgs.Empty);
                    break;
                case "pageClasses":
                    ID = -1;
                    foreach (var row in gridViewClasses.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    if (ID != -1)
                    {
                        foreach (var s in mDBManager.Classes)
                        {
                            if (s.ID == ID)
                            {
                                mDBManager.Classes.Remove(s);
                                break;
                            }
                        }
                    }
                    onSomeFormClosed("ClassForm", EventArgs.Empty);
                    break;
                case "pageClassrooms":
                    ID = -1;
                    foreach (var row in gridViewClassrooms.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    if (ID != -1)
                    {
                        foreach (var s in mDBManager.Classrooms)
                        {
                            if (s.ID == ID)
                            {
                                mDBManager.Classrooms.Remove(s);
                                break;
                            }
                        }
                    }
                    onSomeFormClosed("ClassroomForm", EventArgs.Empty);
                    break;
                case "pageLessons":
                    ID = -1;
                    foreach (var row in gridViewLessons.Rows)
                    {
                        if (row.IsSelected)
                        {
                            ID = (int)row.Tag;
                            break;
                        }
                    }
                    if (ID != -1)
                    {
                        foreach (var s in mDBManager.Lessons)
                        {
                            if (s.ID == ID)
                            {
                                mDBManager.Lessons.Remove(s);
                                break;
                            }
                        }
                    }
                    onSomeFormClosed("LessonForm", EventArgs.Empty);
                    break;
            }
        }

        void onSomeFormClosed(object sender, EventArgs e)
        {
            int currentRowClassrooms = -1;
            int currentRowClasses = -1;
            int currentRowSubjects = -1;
            int currentRowTeachers = -1;
            int currentRowLessons = -1;
            try
            {
                currentRowClassrooms = gridViewClassrooms.SelectedRows[0].Index;
                currentRowClasses = gridViewClasses.SelectedRows[0].Index;
                currentRowSubjects = gridViewSubjects.SelectedRows[0].Index;
                currentRowTeachers = gridViewTeachers.SelectedRows[0].Index;
                currentRowLessons = gridViewLessons.SelectedRows[0].Index;
            }
            catch
            {

            }

            int i = 0;
            if(sender.ToString().Contains("ClassForm")){
                gridViewClasses.Rows.Clear();
                
                foreach (var cl in mDBManager.Classes)
                {
                    gridViewClasses.Rows.Add(cl.Name, cl.ShortName, cl.Grade, "██");
                    gridViewClasses.Rows[i].Cells[3].Style.ForeColor = cl.Color;
                    gridViewClasses.Columns[3].TextAlignment = ContentAlignment.BottomCenter;
                    gridViewClasses.Rows[i].Tag = cl.ID;
                    i++;
                }
                i = 0;
                if (currentRowClasses != -1)
                {
                    foreach (var row in gridViewClasses.Rows)
                    {
                        if (row.Index == currentRowClasses)
                        {
                            row.IsSelected = true;
                            row.IsCurrent = true;
                        }
                        i++;
                    }
                }
            }

            if (sender.ToString().Contains("TeacherForm"))
            {
                gridViewTeachers.Rows.Clear();
                i = 0;
                foreach (var t in mDBManager.Teachers)
                {
                    string g = "мъж";
                    if (t.Gender == Gender.Female) g = "жена";
                    gridViewTeachers.Rows.Add(t.Name, t.ShortName, "██", g);
                    gridViewTeachers.Rows[i].Cells[2].Style.ForeColor = t.Color;
                    gridViewTeachers.Columns[2].TextAlignment = ContentAlignment.BottomCenter;
                    gridViewTeachers.Rows[i].Tag = t.ID;
                    i++;
                }
                i = 0;
                if (currentRowTeachers != -1)
                {
                    foreach (var row in gridViewTeachers.Rows)
                    {
                        if (row.Index == currentRowTeachers)
                        {
                            row.IsSelected = true;
                            row.IsCurrent = true;
                        }
                        i++;
                    }
                }
            }

            if (sender.ToString().Contains("SubjectForm"))
            {
                gridViewSubjects.Rows.Clear();

                i = 0;
                foreach (var s in mDBManager.Subjects)
                {
                    string d = "ниска";
                    if (s.Difficulty == RelativeSubjectDifficulty.Normal) d = "средна";
                    else if (s.Difficulty == RelativeSubjectDifficulty.High) d = "висока";
                    gridViewSubjects.Rows.Add(s.Name, s.ShortName, "██", d);
                    gridViewSubjects.Rows[i].Cells[2].Style.ForeColor = s.Color;
                    gridViewSubjects.Columns[2].TextAlignment = ContentAlignment.BottomCenter;
                    gridViewSubjects.Rows[i].Tag = s.ID;
                    i++;
                }
                i = 0;
                if (currentRowSubjects != -1)
                {
                    foreach (var row in gridViewSubjects.Rows)
                    {
                        if (row.Index == currentRowSubjects)
                        {
                            row.IsSelected = true;
                            row.IsCurrent = true;
                        }
                        i++;
                    }
                }
            }

            if (sender.ToString().Contains("ClassroomForm"))
            {
                gridViewClassrooms.Rows.Clear();

                i = 0;
                foreach (var cl in mDBManager.Classrooms)
                {
                    string isHome = "Не";
                    if (cl.IsHomeClassroom)
                    {
                        isHome = "Да";
                    }

                    string isSpecialisated = "Не";
                    if (cl.IsSpecialisated)
                    {
                        isSpecialisated = "Да";
                    }
                    gridViewClassrooms.Rows.Add(cl.Name, cl.ShortName, "██", isHome, isSpecialisated);
                    gridViewClassrooms.Rows[i].Cells[2].Style.ForeColor = cl.Color;
                    gridViewClassrooms.Columns[2].TextAlignment = ContentAlignment.BottomCenter;
                    gridViewClassrooms.Rows[i].Tag = cl.ID;
                    Console.WriteLine("ID: {0}", cl.ID);
                    i++;
                }

                if (currentRowClassrooms != -1)
                {
                    i = 0;
                    foreach (var row in gridViewClassrooms.Rows)
                    {
                        if (row.Index == currentRowClassrooms)
                        {
                            row.IsSelected = true;
                            row.IsCurrent = true;
                        }
                        i++;
                    }
                }
            }

            if (sender.ToString().Contains("LessonForm"))
            {
                gridViewLessons.Rows.Clear();
                i = 0;
                foreach (var lesson in mDBManager.Lessons)
                {
                    string hourlen = "";
                    switch (lesson.HourLenght)
                    {
                        case HourLenght.DoubleHour:
                            hourlen = "Двоен час"; break;
                        case HourLenght.SingleHour:
                            hourlen = "Единичен час"; break;
                        case HourLenght.NoMatter:
                            hourlen = "Без значение"; break;
                    }
                    gridViewLessons.Rows.Add(lesson.Subject.Name,
                        lesson.Class.Name,
                        lesson.Teacher.Name,
                        lesson.HoursPerWeek,
                        hourlen);
                    gridViewLessons.Rows[i].Tag = lesson.ID;
                    i++;
                }

                if (currentRowLessons != -1)
                {
                    i = 0;
                    foreach (var row in gridViewLessons.Rows)
                    {
                        if (row.Index == currentRowLessons)
                        {
                            row.IsSelected = true;
                            row.IsCurrent = true;
                        }
                        i++;
                    }
                }
            }
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            long ID = 0;
            foreach (var row in gridViewClasses.Rows)
            {
                if (row.IsSelected)
                {
                    ID = (int)row.Tag;
                    break;
                }
            }
            openForm(FormTypes.EditGroups , ID);
        }
        
        private void pageviewManageDatabase_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageviewManageDatabase.SelectedPage.Name == "pageClasses")
            {
                buttonGroups.Visible = true;
            }
            else
            {
                buttonGroups.Visible = false;
            }
        }
    }
}
