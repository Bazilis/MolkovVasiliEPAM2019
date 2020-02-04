using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    public abstract class AbstractCreator
    {
        public abstract ICRUD<Exam> GetExamDAO();

        public abstract ICRUD<Group> GetGroupDAO();

        public abstract ICRUD<Result> GetResultDAO();

        public abstract ICRUD<Student> GetStudentDAO();

        public abstract ICRUD<Subject> GetSubjectDAO();
    }
}
