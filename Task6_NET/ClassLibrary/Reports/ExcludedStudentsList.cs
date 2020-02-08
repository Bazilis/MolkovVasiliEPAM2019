using System;
using System.Linq;
using System.Collections.Generic;
using ClassLibrary.DatabaseDataModels;
using ClassLibrary.DataAccessObjectsFactory;

namespace ClassLibrary.Reports
{
    /// <summary>
    /// Сreates a list of students for expulsion
    /// </summary>
    public class ExcludedStudentsList
    {
        private ICRUD<Exam> examDAO;
        private ICRUD<Group> groupDAO;
        private ICRUD<Result> resultDAO;
        private ICRUD<Student> studentDAO;
        private ICRUD<Subject> subjectDAO;

        public ExcludedStudentsList(AbstractCreator creatorDAO)
        {
            examDAO = creatorDAO.GetExamDAO();
            groupDAO = creatorDAO.GetGroupDAO();
            resultDAO = creatorDAO.GetResultDAO();
            studentDAO = creatorDAO.GetStudentDAO();
            subjectDAO = creatorDAO.GetSubjectDAO();
        }

        public List<IGrouping<int, Student>> GetExcludedStudentsList(double minimalStudentsGrade, int maximalNumberOfMinimalStudentsGrades)
        {
            List<Exam> exams = examDAO.ReadAll();
            List<Group> groups = groupDAO.ReadAll();
            List<Result> results = resultDAO.ReadAll();
            List<Student> students = studentDAO.ReadAll();
            List<Subject> subjects = subjectDAO.ReadAll();

            IEnumerable<Student> lowGradeStudents =
                from student in students
                join result in results on student.Id equals result.StudentId
                where result.StudentsGrade < minimalStudentsGrade
                select student;

            if (lowGradeStudents == null || !lowGradeStudents.GetEnumerator().MoveNext())
            {
                throw new Exception("Students with low grade is not found");
            }
            else
            {
                List<Student> excludedStudens = new List<Student>();

                foreach (Student student in lowGradeStudents.ToList())
                {
                    if (lowGradeStudents.ToList().FindAll(s => s.Id == student.Id).Count >= maximalNumberOfMinimalStudentsGrades)
                    {
                        excludedStudens.Add(student);
                    }
                }

                return excludedStudens.Distinct().GroupBy(g => g.GroupId).ToList();
            }
        }
    }
}
