using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using ScheduleWorks.Utility;

namespace ScheduleWorks.DBImport
{
    public class Import
    {
        #region Members
        private string mFileName;
        private List<ClassType> mTypes;
        private List<EducationForm> mEducationForms;
        private List<BasicClass> mBasicClasses;
        private List<Class> mClasses;
        private List<Subject> mSubjects;
        private List<Teacher> mTeachers;
        private List<Curriculum> mCurriculums;
        #endregion

        #region Constructors
        public Import(string fileName)
        {
            this.FileName = fileName;
            this.mTypes = new List<ClassType>{ };
            this.mEducationForms = new List<EducationForm>{ };
            this.mBasicClasses = new List<BasicClass>{ };
            this.mClasses = new List<Class>{ };
            this.mSubjects = new List<Subject>{ };
            this.mTeachers = new List<Teacher>{ };
            this.mCurriculums = new List<Curriculum> { };
            BeginImport();
        }
        #endregion

        private void BeginImport()
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                      "Data Source=" + this.mFileName;
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                ImportClassTypes(ref connection);
                ImportEducationForms(ref connection);
                ImportBasicClasses(ref connection);
                ImportClasses(ref connection);
                ImportSubjects(ref connection);
                ImportTeachers(ref connection);
                ImportCurriculum(ref connection);
            }
            finally
            {
                connection.Close();
            }

            #region Setting of the next indexes

            IndexMaker.LastIndexOfClasses = mClasses.Count - 1;
            IndexMaker.LastIndexOfTeachers = mTeachers.Count - 1;
            IndexMaker.LastIndexOfSubjects = mSubjects.Count - 1;
            IndexMaker.LastIndexOfLessons = mCurriculums.Count - 1;

            #endregion

        }

        #region Internal import functions
        private void ImportClassTypes(ref OleDbConnection connection)
        {
            string ClassTypesSelect = "SELECT [ClassType Id] AS ID, [ClassType Name] AS Name, [ClassType SN] AS ShortName " +
                                      "FROM [Code ClassType]";
            OleDbCommand command = new OleDbCommand(ClassTypesSelect, connection);
            using (OleDbDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    ClassType classType = new ClassType(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Name"].ToString(),
                        dataReader["ShortName"].ToString());
                    this.mTypes.Add(classType);
                }
            }
        }

        private void ImportEducationForms(ref OleDbConnection connection)
        {
            string EducationFormsSelect = "SELECT [EdForm ID] AS ID, [EdForm Name] AS Name, [EdFormSN] AS ShortName " +
                                          "FROM [Code EdForm]";
            OleDbCommand command = new OleDbCommand(EducationFormsSelect, connection);
            using (OleDbDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    EducationForm form = new EducationForm(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Name"].ToString(),
                        dataReader["ShortName"].ToString());
                    this.mEducationForms.Add(form);
                }
            }
        }

        private void ImportBasicClasses(ref OleDbConnection connection)
        {
            string BasicClassesSelect = "SELECT [BClass ID] AS ID, [BClass Name] AS NameDigits, [BClass Recode] AS NameWords, [BClassNameRome] AS NameRomeDigits " +
                                        "FROM BasicClass";
            OleDbCommand command = new OleDbCommand(BasicClassesSelect, connection);
            using (OleDbDataReader dataReader = command.ExecuteReader())
            {

                while (dataReader.Read())
                {
                    BasicClass basicClass = new BasicClass(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["NameDigits"].ToString(),
                        dataReader["NameWords"].ToString(),
                        dataReader["NameRomeDigits"].ToString());
                    this.mBasicClasses.Add(basicClass);
                }
            }
        }

        private void ImportClasses(ref OleDbConnection connection)
        {
            string DetailsSelect = "SELECT [cd].[Class] AS [Class], " +
                                   "[cd].Group AS [Group], " +
                                   "[cd].[ClassType] AS [ClassTypeID], " +
                                   "cd.[BasicClass] AS [BasicClassID], " +
                                   "cd.[ClassEdform] AS [EducationFormID]" +
                                   "FROM [Class Details] cd";
            OleDbCommand DetailsQuery = new OleDbCommand(DetailsSelect, connection);
            List<ClassDetails> AllDetails = new List<ClassDetails> { };
            using (OleDbDataReader DetailsReader = DetailsQuery.ExecuteReader())
            {
                while (DetailsReader.Read())
                {
                    ClassDetails d = new ClassDetails(int.Parse(DetailsReader["Class"].ToString()),
                                                      int.Parse(DetailsReader["Group"].ToString()),
                                                      this.mTypes.Single(x => x.ID == int.Parse(DetailsReader["ClassTypeID"].ToString())).ShallowCopy(),
                                                      this.mBasicClasses.Single(x => x.ID == int.Parse(DetailsReader["BasicClassID"].ToString())).ShallowCopy(),
                                                      this.mEducationForms.Single(x => x.ID == int.Parse(DetailsReader["EducationFormID"].ToString())).ShallowCopy());
                    AllDetails.Add(d);
                }
            }
            string ClassesSelect = "SELECT [cc].[Class ID] AS [ID], [p].[Paralell class Name] AS [Division], [cc].[Class No] AS [Number] FROM [Code Class] AS [cc] LEFT JOIN [Code Paralell class] AS [p] ON [cc].[Class No] = [p].[Paralell class ID]";
            OleDbCommand ClassesQuery = new OleDbCommand(ClassesSelect, connection);
            using (OleDbDataReader ClassesReader = ClassesQuery.ExecuteReader())
            {
                while (ClassesReader.Read())
                {
                    BasicClass bc = this.mBasicClasses.Single(x => x.ID == int.Parse(ClassesReader["Number"].ToString()));
                    int id = int.Parse(ClassesReader["ID"].ToString());
                    List<ClassDetails> details = AllDetails.Where(x => x.ID == id).ToList();
                    Class c = new Class(id,
                                        ClassesReader["Division"].ToString(),
                                        bc);
                    foreach (var item in details)
                    {
                        item.SetDetailed(c);
                    }
                    c.SetDetails(details);
                    c.ShortName = c.Name;
                    this.mClasses.Add(c);
                }
            }
        }

        private void ImportSubjects(ref OleDbConnection connection)
        {
            string SubjectGroupsSelect = "SELECT * FROM [Code SubjectGroup]";
            OleDbCommand ClassesQuery = new OleDbCommand(SubjectGroupsSelect, connection);
            
            Dictionary<int, SubjectGroup> d = new Dictionary<int, SubjectGroup>() { };
            using (OleDbDataReader GroupsReader = ClassesQuery.ExecuteReader())
            {
                while (GroupsReader.Read())
                {
                    int id = int.Parse(GroupsReader["SubjGroup ID"].ToString());
                    int norma;
                    if (int.TryParse(GroupsReader["NormaBasic"].ToString(), out norma) == false)
                    {
                        norma = 0;
                    }
                    SubjectGroup group = new SubjectGroup(
                        id,
                        GroupsReader["SubjGroup Name"].ToString(),
                        norma);
                    d.Add(id, group);
                }
            }
            string SubjectsSelect = "SELECT * FROM [Code Subject] WHERE [Subject Name] IS NOT NULL";
            OleDbCommand SubjectsQuery = new OleDbCommand(SubjectsSelect, connection);
            using (OleDbDataReader SubjectsReader = SubjectsQuery.ExecuteReader())
            {
                while (SubjectsReader.Read())
                {
                    int id = int.Parse(SubjectsReader["Subject ID"].ToString());
                    
                    int group_id = int.Parse(SubjectsReader["SubjectGroup"].ToString());
                    string name = SubjectsReader["Subject Name"].ToString();
                    SubjectGroup gr = d[group_id];
                    Subject s = new Subject(id, name, gr);
                    this.mSubjects.Add(s);
                }
            }
        }

        private void ImportTeachers(ref OleDbConnection connection)
        {
            string TeachersSelect = "SELECT * FROM [Teachers - personal status]";
            OleDbCommand ClassesQuery = new OleDbCommand(TeachersSelect, connection);
            using (OleDbDataReader TeachersReader = ClassesQuery.ExecuteReader())
            {
                while (TeachersReader.Read())
                {
                    Gender g;
                    if (TeachersReader["Sex-feminine"].ToString().Equals("True"))
                    {
                        g = Gender.Female;
                    }
                    else
                    {
                        g = Gender.Male;
                    }
                    Teacher t = new Teacher(long.Parse(TeachersReader["ID Number"].ToString()),
                                            TeachersReader["First Name"].ToString(),
                                            TeachersReader["Second Name"].ToString(),
                                            TeachersReader["Family Name"].ToString(),
                                            g);
                    this.mTeachers.Add(t);
                }
            }
        }

        private void ImportCurriculum(ref OleDbConnection connection)
        {
            string CurriculumSelect = @"SELECT cl.[Hours weekly1] AS HoursPerWeek, cl.CurricID AS [CurricID], cl.[Class] AS [Class], cl.Subject AS Subject, cl.[Group] AS [Group], p.[ID number] AS [TeacherID] FROM [CurriculumL] AS [cl] INNER JOIN [CurriculumTeachers] AS [p] ON [cl].[CurricID] = [p].[CurricID] WHERE cl.[Class] IS NOT NULL";
            //string CurriculumSelect = "SELECT * FROM CurriculumL "; //+
                                      //"JOIN CurriculumTeachers ct ON ct.CurricID = CurriculumL.CurricID ORDER BY CurricID";
            OleDbCommand command = new OleDbCommand(CurriculumSelect, connection);
            using (OleDbDataReader CurriculumReader = command.ExecuteReader())
            {
                while (CurriculumReader.Read())
                {
                    int id = int.Parse(CurriculumReader["CurricID"].ToString());
                    int classid = int.Parse(CurriculumReader["Class"].ToString());
                    int groupid = int.Parse(CurriculumReader["Group"].ToString());
                    int subjectid = int.Parse(CurriculumReader["Subject"].ToString());
                    int hoursPerWeek = (int)double.Parse(CurriculumReader["HoursPerWeek"].ToString());
                    long teacherid = long.Parse(CurriculumReader["TeacherID"].ToString());
                    Class c = this.mClasses.SingleOrDefault(x => x.ID == classid);
                    ClassDetails group = c.Details.SingleOrDefault(x => x.Group == groupid);
                    Subject subject = this.mSubjects.SingleOrDefault(x => x.ID == subjectid);
                    Teacher teacher = this.mTeachers.SingleOrDefault(x => x.ID == teacherid);
                    Curriculum curric = new Curriculum(id, subject, c, group, teacher, hoursPerWeek);
                    this.mCurriculums.Add(curric);
                }
            }
        }

        #endregion

        #region Properties

        public string FileName
        {
            get
            {
                return this.mFileName;
            }
            private set
            {
                //check if file exists
                this.mFileName = value;
            }
        }

        public ReadOnlyCollection<ClassType> Types
        {
            get
            {
                return this.mTypes.AsReadOnly();
            }
        }

        public ReadOnlyCollection<EducationForm> EducationForms
        {
            get
            {
                return this.mEducationForms.AsReadOnly();
            }
        }

        public ReadOnlyCollection<BasicClass> BasicClasses
        {
            get
            {
                return this.mBasicClasses.AsReadOnly();
            }
        }

        public ReadOnlyCollection<Class> Classes
        {
            get
            {
                return this.mClasses.AsReadOnly();
            }
        }

        //you shouldn't uncomment this
        //data is readonly
        /*
        public List<Class> ClassesEditable
        {
            get
            {
                return this.mClasses;
            }
        }*/

        public ReadOnlyCollection<Subject> Subjects
        {
            get
            {
                return this.mSubjects.AsReadOnly();
            }
        }

        public ReadOnlyCollection<Teacher> Teachers
        {
            get
            {
                return this.mTeachers.AsReadOnly();
            }
        }

        public ReadOnlyCollection<Curriculum> Curriculums
        {
            get
            {
                return this.mCurriculums.AsReadOnly();
            }
        }
        #endregion
    }
}
