using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleApp.ReportsDataModels;
using ConsoleApp.DatabaseDataModels;
using ConsoleApp.DataAccessObjectsFactory;

namespace ConsoleApp.Reports
{
    public class SpecialtyAverageGradeReport : IReport
    {
        private ICRUD<Exam> examDAO;
        private ICRUD<Group> groupDAO;
        private ICRUD<Result> resultDAO;
        private ICRUD<Specialty> specialtyDAO;

        private Func<SpecialtyAverageGradeResult, object> OrderBy { get; set; }

        private bool OrderByDescending { get; set; }

        private int SessionNumber { get; set; }

        public SpecialtyAverageGradeReport(AbstractCreator creatorDAO, int sessionNumber, Func<SpecialtyAverageGradeResult, object> orderBy, bool orderByDescending = false)
        {
            examDAO = creatorDAO.GetExamDAO();
            resultDAO = creatorDAO.GetResultDAO();
            groupDAO = creatorDAO.GetGroupDAO();
            specialtyDAO = creatorDAO.GetSpecialtyDAO();

            OrderBy = orderBy;
            OrderByDescending = orderByDescending;
            SessionNumber = sessionNumber;
        }

        public IEnumerable<string> GetReportHeader()
        {
            return new List<string> {
                "Specialty code", "Specialty name",
                "Specialty describe", "Average grade"
            };
        }

        public IEnumerable<IEnumerable<string>> GetReportTable()
        {
            List<List<string>> resultReportTable = new List<List<string>>();

            foreach (SpecialtyAverageGradeResult specialtyAverageGradeResult in GetSpecialtyAverageGradeTable(SessionNumber, OrderBy, OrderByDescending))
            {
                resultReportTable.Add(new List<string>
                {
                    specialtyAverageGradeResult.SpecialtyCode,
                    specialtyAverageGradeResult.SpecialtyName,
                    specialtyAverageGradeResult.SpecialtyDescribe,
                    string.Format("{0:0.00}", specialtyAverageGradeResult.SpecialtyAverageGrade),
                });
            }

            return resultReportTable;
        }

        private IOrderedEnumerable<SpecialtyAverageGradeResult> GetSpecialtyAverageGradeTable(int sessionNumber, Func<SpecialtyAverageGradeResult, object> orderBy, bool orderByDescending = false)
        {
            IEnumerable<Specialty> sessionNumberSpecialties = (from specialty in specialtyDAO.ReadAll()
                join grp in groupDAO.ReadAll() on specialty.Id equals grp.SpecialtyId
                join exam in examDAO.ReadAll() on grp.Id equals exam.GroupId
                join result in resultDAO.ReadAll() on exam.Id equals result.ExamId
                where exam.SessionNumber == sessionNumber
                select specialty).Distinct();


            List<SpecialtyAverageGradeResult> resultAverageGradeRow = new List<SpecialtyAverageGradeResult>();

            foreach (Specialty item in sessionNumberSpecialties)
            {
                IEnumerable<Result> sessionNumberSpecialtiesResults = from specialty in specialtyDAO.ReadAll()
                    join grp in groupDAO.ReadAll() on specialty.Id equals grp.SpecialtyId
                    join exam in examDAO.ReadAll() on grp.Id equals exam.GroupId
                    join result in resultDAO.ReadAll() on exam.Id equals result.ExamId
                    where item.Id == specialty.Id
                    select result;

                double? specialtyAverageResult = sessionNumberSpecialtiesResults.Average(s => s.StudentsGrade);

                resultAverageGradeRow.Add(new SpecialtyAverageGradeResult
                {
                    SpecialtyCode = item.SpecialtyCode,
                    SpecialtyName = item.SpecialtyName,
                    SpecialtyDescribe = item.SpecialtyDescribe,
                    SpecialtyAverageGrade = specialtyAverageResult
                });
            }


            if (resultAverageGradeRow == null || !resultAverageGradeRow.GetEnumerator().MoveNext())
            {
                throw new Exception("Average grade results is not found");
            }


            IOrderedEnumerable<SpecialtyAverageGradeResult> orderedSpecialtyResultRows;

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
