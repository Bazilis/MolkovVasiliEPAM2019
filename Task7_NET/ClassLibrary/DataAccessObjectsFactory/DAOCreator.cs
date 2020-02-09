using System;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public class DAOCreator : AbstractCreator
    {
        public static string ConnectionString { get; private set; }

        private static DAOCreator Instance;

        private DAOCreator()
        { }

        public static DAOCreator GetInstance(string connectionString)
        {
            if (Instance == null)
            {
                Instance = new DAOCreator();
                ConnectionString = connectionString;
            }
            return Instance;
        }

        public override ICRUD<Exam> GetExamDAO()
        {
            return new ExamDAO(ConnectionString);
        }

        public override ICRUD<Group> GetGroupDAO()
        {
            return new GroupDAO(ConnectionString);
        }

        public override ICRUD<Result> GetResultDAO()
        {
            return new ResultDAO(ConnectionString);
        }

        public override ICRUD<Student> GetStudentDAO()
        {
            return new StudentDAO(ConnectionString);
        }

        public override ICRUD<Subject> GetSubjectDAO()
        {
            return new SubjectDAO(ConnectionString);
        }

        public override ICRUD<Examiner> GetExaminerDAO()
        {
            return new ExaminerDAO(ConnectionString);
        }

        public override ICRUD<Specialty> GetSpecialtyDAO()
        {
            return new SpecialtyDAO(ConnectionString);
        }
    }
}
