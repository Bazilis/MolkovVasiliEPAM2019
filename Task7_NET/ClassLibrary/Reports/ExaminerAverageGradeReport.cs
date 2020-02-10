using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleApp.ReportsDataModels;
using ConsoleApp.DatabaseDataModels;
using ConsoleApp.DataAccessObjectsFactory;

namespace ConsoleApp.Reports
{
    public class ExaminerAverageGradeReport : IReport
    {
        private ICRUD<Exam> examDAO;
        private ICRUD<Result> resultDAO;
        private ICRUD<Examiner> examinerDAO;

        private Func<ExaminerAverageGradeResult, object> OrderBy { get; set; }

        private bool OrderByDescending { get; set; }

        private int SessionNumber { get; set; }

        public ExaminerAverageGradeReport(AbstractCreator creatorDAO, int sessionNumber, Func<ExaminerAverageGradeResult, object> orderBy, bool orderByDescending = false)
        {
            examDAO = creatorDAO.GetExamDAO();
            resultDAO = creatorDAO.GetResultDAO();
            examinerDAO = creatorDAO.GetExaminerDAO();

            OrderBy = orderBy;
            OrderByDescending = orderByDescending;
            SessionNumber = sessionNumber;
        }

        public IEnumerable<string> GetReportHeader()
        {
            return new List<string> {
                "Examiner surname", "Examiner name", 
                "Examiner patronymic", "Average grade"
            };
        }

        public IEnumerable<IEnumerable<string>> GetReportTable()
        {
            List<List<string>> resultReportTable = new List<List<string>>();

            foreach (ExaminerAverageGradeResult examinerAverageGradeResult in GetExaminerAverageGradeTable(SessionNumber, OrderBy, OrderByDescending))
            {
                resultReportTable.Add(new List<string>
                {
                    examinerAverageGradeResult.ExaminerSurname,
                    examinerAverageGradeResult.ExaminerName,
                    examinerAverageGradeResult.ExaminerPatronymic,
                    string.Format("{0:0.00}", examinerAverageGradeResult.ExaminerAverageGrade),
                });
            }

            return resultReportTable;
        }

        private IOrderedEnumerable<ExaminerAverageGradeResult> GetExaminerAverageGradeTable(int sessionNumber, Func<ExaminerAverageGradeResult, object> orderBy, bool orderByDescending = false)
        {
            IEnumerable<Examiner> sessionNumberExaminers = (from examiner in examinerDAO.ReadAll()
                join exam in examDAO.ReadAll() on examiner.Id equals exam.ExaminerId
                where exam.SessionNumber == sessionNumber
                select examiner).Distinct();


            List<ExaminerAverageGradeResult> resultAverageGradeRow = new List<ExaminerAverageGradeResult>();

            foreach (Examiner ex in sessionNumberExaminers)
            {
                IEnumerable<Result> sessionNumberExaminersResults = from result in resultDAO.ReadAll()
                    join exam in examDAO.ReadAll() on result.ExamId equals exam.Id
                    join examiner in examinerDAO.ReadAll() on exam.ExaminerId equals examiner.Id
                    where exam.SessionNumber == sessionNumber & examiner.Id == ex.Id
                    select result;

                double? examinerAverageResult = sessionNumberExaminersResults.Average(x => x.StudentsGrade);

                resultAverageGradeRow.Add(new ExaminerAverageGradeResult
                {
                    ExaminerName = ex.ExaminerName,
                    ExaminerSurname = ex.ExaminerSurname,
                    ExaminerPatronymic = ex.ExaminerPatronymic,
                    ExaminerAverageGrade = examinerAverageResult
                });
            }

            if (resultAverageGradeRow == null || !resultAverageGradeRow.GetEnumerator().MoveNext())
            {
                throw new Exception("Average grade results is not found");
            }


            IOrderedEnumerable<ExaminerAverageGradeResult> orderedSpecialtyResultRows;

            if (orderByDescending == false)
            {
                orderedSpecialtyResultRows = resultAverageGradeRow.OrderBy(orderBy);
            }
            else
            {
                orderedSpecialtyResultRows = resultAverageGradeRow.OrderByDescending(orderBy);
            }

            return orderedSpecialtyResultRows;
        }
    }
}
