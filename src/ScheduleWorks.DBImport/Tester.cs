using System;

namespace ScheduleWorks.DBImport
{
    public class Tester
    {
        public static void Main()
        {
            Import import = new Import(@"D:\ScheduleWorks\Data.mdb");
            Console.WriteLine("hey: {0}", import.Subjects.Count);
            /*BasicClass b = new BasicClass(1, "1", "first", "I");
            EducationForm e = new EducationForm(1, "day'n'night", "dnn");
            Class shit = new Class(1, "a", b);
            List<ClassDetails> details = new List<ClassDetails> { new ClassDetails(2, 0, new ClassType(1, "die", "die"), b, e) };
            details[0].SetDetailed(shit);
            shit.SetDetails(details);
            Console.WriteLine(shit.Division);
            shit.Details[0].Detailed.Division = "die, motherfucker!";
            Console.WriteLine(shit.Division);*/
            foreach (var item in import.Curriculums)
            {
                Console.WriteLine("{0}\n{1} {2}\n{3} {4}",
                    item.ID,
                    item.Class.Division, item.Class.Grade,
                    item.Subject.Name,
                    item.HoursPerWeek);
            }
        }
    }
}
