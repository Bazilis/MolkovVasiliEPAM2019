using System;
using System.Linq;
using System.Collections.Generic;
using ClassLibrary.ReportsDataModels;
using ClassLibrary.DatabaseDataModels;
using ClassLibrary.DataAccessObjectsFactory;

namespace ClassLibrary.Reports
{
    public class ForEachGroupSessionsResults : IReport
    {
        private ICRUD<Exam> examDAO;
        private ICRUD<Group> groupDAO;
        private ICRUD<Result> resultDAO;
        private ICRUD<Student> studentDAO;
        private ICRUD<Subject> subjectDAO;

        private int SessionNumber { get; set; }

        private Func<StudentSessionResult, object> OrderBy { get; set; }

        private bool OrderByDescending { get; set; }

        private IEnumerable<int> AllGroupIds { get; set; }

        public ForEachGroupSessionsResults(AbstractCreator creatorDAO, int sessionNumber, Func<StudentSessionResult, object> orderBy, bool orderByDescending = false)
        {
            examDAO = creatorDAO.GetExamDAO();
            groupDAO = creatorDAO.GetGroupDAO();
            resultDAO = creatorDAO.GetResultDAO();
            studentDAO = creatorDAO.GetStudentDAO();
            subjectDAO = creatorDAO.GetSubjectDAO();

            SessionNumber = sessionNumber;

            OrderBy = orderBy;
            OrderByDescending = orderByDescending;

            AllGroupIds = groupDAO.ReadAll().Select(s => s.Id).Distinct().OrderBy(o => o);
        }

        public IEnumerable<string> GetReportHeader()
        {
            return new List<string> {
                "Surname", "Name", "Patronymic", "Date of birth",
                "Gender", "Subject name", "Subject type",
                "Exam date", "Student's grade"
            };
        }

        public IEnumerable<IEnumerable<IEnumerable<string>>> GetReportTables()
        {
            List<List<string>> groupSessionResultsTable = new List<List<string>>();
            List<List<List<string>>> groupSessionResultsTables = new List<List<List<string>>>();

            foreach (int groupId in AllGroupIds)
            {
                foreach (StudentSessionResult studentSessionResults in GetGroupSessionResultsTable(SessionNumber, groupId, OrderBy, OrderByDescending))
                {
                    groupSessionResultsTable.Add(new List<string>
                    {
                        studentSessionResults.Surname,
                        studentSessionResults.Name,
                        studentSessionResults.Patronymic,
                        studentSessionResults.DateOfBirth.ToString("MM/dd/yyyy"),
                        studentSessionResults.Gender,
                        studentSessionResults.SubjectName,
                        studentSessionResults.SubjectType,
                        studentSessionResults.ExamDate.ToString("MM/dd/yyyy"),
                        string.Format("{0:0.00}", studentSessionResults.StudentsGrade)
                    });
                }

                groupSessionResultsTables.Add(groupSessionResultsTable);
                groupSessionResultsTable.Clear();
            }
            return groupSessionResultsTables;
        }

        private IEnumerable<StudentSessionResult> GetGroupSessionResultsTable(int sessionNumber, int groupId, Func<StudentSessionResult, object> orderBy, bool orderByDescending = false)
        {
            List<Exam> exams = examDAO.ReadAll();
            List<Group> groups = groupDAO.ReadAll();
            List<Result> results = resultDAO.ReadAll();
            List<Student> students = studentDAO.ReadAll();
            List<Subject> subjects = subjectDAO.ReadAll();

            Group requiredGroup = groups.FirstOrDefault(g => g.Id == groupId);

            IEnumerable<StudentSessionResult> groupSessionResult =
                from student in students
                join result in results on student.Id equals result.StudentId
                join exam in exams on result.ExamId equals exam.Id
                join subject in subjects on exam.SubjectId equals subject.Id
                where student.GroupId == requiredGroup.Id & exam.SessionNumber == sessionNumber

                select new StudentSessionResult
                {
                    Surname = student.Surname,
                    Name = student.Name,
                    Patronymic = student.Patronymic,
                    DateOfBirth = student.DateOfBirth,
                    Gender = student.Gender,
                    ExamDate = exam.ExamDate,
                    SubjectName = subject.SubjectName,
                    SubjectType = subject.SubjectType,
                    StudentsGrade = result.StudentsGrade
                };

            if (groupSessionResult == null)
            {
                throw new Exception("Group session results is not found");
            }

            IEnumerable<StudentSessionResult> orderedGroupSessionResult;

            if (orderByDescending == false)
            {
                orderedGroupSessionResult = groupSessionResult.OrderBy(orderBy);
            }
            else
            {
                orderedGroupSessionResult = groupSessionResult.OrderByDescending(orderBy);
            }

            return orderedGroupSessionResult;
        }
    }
}
