using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    public class FormTitle
    {
        public string Add;
        public string Edit;

        public FormTitle(string aAdd, string aEdit){
            Add = aAdd;
            Edit = aEdit;
        }
    }

    public static class FormTitles
    {
        public static FormTitle ClassroomForm = new FormTitle("Добави нова стая", "Редактирай стая");
        public static FormTitle ClassForm = new FormTitle("Добави нов клас", "Редактирай клас");
        public static FormTitle TacherForm = new FormTitle("Добави нов учител", "Редактирай учител");
        public static FormTitle SubjectForm = new FormTitle("Добави нов предмет", "Редактирай предмет");
        public static FormTitle LessonForm = new FormTitle("Добави нов урок", "Редактирай урок");
    }
}
