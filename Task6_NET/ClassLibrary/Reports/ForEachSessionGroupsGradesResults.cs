using System;
using System.Linq;
using System.Collections.Generic;
using ClassLibrary.ReportsDataModels;
using ClassLibrary.DatabaseDataModels;
using ClassLibrary.DataAccessObjectsFactory;

namespace ClassLibrary.Reports
{
    public class ForEachSessionGroupsGradesResults : IReport
    {
        private ICRUD<Exam> examDAO;
        private ICRUD<Group> groupDAO;
        private ICRUD<Result> resultDAO;

        private Func<GroupGradesResults, object> OrderBy { get; set; }

        private bool OrderByDescending { get; set; }

        private IEnumerable<int> AllSessionNumbers { get; set; }

        public ForEachSessionGroupsGradesResults(AbstractCreator creatorDAO, Func<GroupGradesResults, object> orderBy, bool orderByDescending = false)
        {
            examDAO = creatorDAO.GetExamDAO();
            groupDAO = creatorDAO.GetGroupDAO();
            resultDAO = creatorDAO.GetResultDAO();

            OrderBy = orderBy;
            OrderByDescending = orderByDescending;

            AllSessionNumbers = examDAO.ReadAll().Select(s => s.SessionNumber).Distinct().OrderBy(o => o);
        }

        public IEnumerable<string> GetReportHeader()
        {
            return new List<string> {
                "Group name", "Mininum grade of students",
                "Maximum grade of students", "Average grade of students"
            };
        }

        public IEnumerable<IEnumerable<IEnumerable<string>>> GetReportTables()
        {
            List<List<string>> groupsGradesResultsTable = new List<List<string>>();
            List<List<List<string>>> groupsGradesResultsTables = new List<List<List<string>>>();

            foreach (int sessionNumber in AllSessionNumbers)
            {
                foreach (GroupGradesResults groupGradesResults in GetGrupsGradesResultsTable(sessionNumber, OrderBy, OrderByDescending))
                {
                    groupsGradesResultsTable.Add(new List<string>
                    {
                        groupGradesResults.GroupName,
                        string.Format("{0:0.00}", groupGradesResults.MinGradeOfStudents),
                        string.Format("{0:0.00}", groupGradesResults.MaxGradeOfStudents),
                        string.Format("{0:0.00}", groupGradesResults.AverageGradeOfStudents),
                    });
                }

                groupsGradesResultsTables.Add(groupsGradesResultsTable);
                groupsGradesResultsTable.Clear();
            }
            return groupsGradesResultsTables;
        }

        private IEnumerable<GroupGradesResults> GetGrupsGradesResultsTable(int sessionNumber, Func<GroupGradesResults, object> orderBy, bool orderByDescending = false)
        {
            List<Exam> exams = examDAO.ReadAll();
            List<Group> groups = groupDAO.ReadAll();
            List<Result> results = resultDAO.ReadAll();

            IEnumerable<int> sessionGroupsKeys = exams.
                Where(w => w.SessionNumber == sessionNumber).
                GroupBy(g => g.GroupId).
                Where(w => w.Count() >= 1).
                Select(s => s.Key);

            List<GroupGradesResults> groupGradesResults = new List<GroupGradesResults>();

            foreach (int key in sessionGroupsKeys)
            {
                IEnumerable<Result> sessionResults =
                    from result in results
                    join exam in exams on result.ExamId equals exam.Id
                    where exam.SessionNumber == sessionNumber & exam.GroupId == key
                    select result;

                double? minGradeOfStudents = sessionResults.Min(g => g.StudentsGrade);
                double? maxGradeOfStudents = sessionResults.Max(m => m.StudentsGrade);
                double? averageGradeOfStudents = sessionResults.Average(a => a.StudentsGrade);

                Group groupName = groups.FirstOrDefault(g => g.Id == key);

                groupGradesResults.Add(new GroupGradesResults
                {
                    GroupName = groupName.GroupName,
                    MinGradeOfStudents = (double)minGradeOfStudents,
                    MaxGradeOfStudents = (double)maxGradeOfStudents,
                    AverageGradeOfStudents = (double)averageGradeOfStudents
                });
            }

            if (groupGradesResults == null || !groupGradesResults.GetEnumerator().MoveNext())
            {
                throw new Exception("Group grades results is not found");
            }
            else
            {
                IEnumerable<GroupGradesResults> orderedGroupGradesResults;

                if (orderByDescending == false)
                {
                    orderedGroupGradesResults = groupGradesResults.OrderBy(orderBy);
                }
                else
                {
                    orderedGroupGradesResults = groupGradesResults.OrderByDescending(orderBy);
                }
                return orderedGroupGradesResults;
            }
        }
    }
}
