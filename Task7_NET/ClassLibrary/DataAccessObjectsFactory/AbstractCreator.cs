using System;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public abstract class AbstractCreator
    {
        public abstract ICRUD<Exam> GetExamDAO();

        public abstract ICRUD<Group> GetGroupDAO();

        public abstract ICRUD<Result> GetResultDAO();

        public abstract ICRUD<Student> GetStudentDAO();

        public abstract ICRUD<Subject> GetSubjectDAO();

        public abstract ICRUD<Examiner> GetExaminerDAO();

        public abstract ICRUD<Specialty> GetSpecialtyDAO();
    }
}
