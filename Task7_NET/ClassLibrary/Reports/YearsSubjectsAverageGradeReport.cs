using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using ConsoleApp.DatabaseDataModels;
using ConsoleApp.DataAccessObjectsFactory;

namespace ConsoleApp.Reports
{
    public class YearsSubjectsAverageGradeReport : IReport
    {
        private ICRUD<Exam> examDAO;
        private ICRUD<Result> resultDAO;
        private ICRUD<Subject> subjectDAO;

        private bool OrderByYearDescending { get; set; }

        private bool OrderBySubjectDescending { get; set; }

        public YearsSubjectsAverageGradeReport(AbstractCreator creatorDAO, bool orderByYearsDescending = false, bool orderBySubjectDescending = false)
        {
            examDAO = creatorDAO.GetExamDAO();
            resultDAO = creatorDAO.GetResultDAO();
            subjectDAO = creatorDAO.GetSubjectDAO();

            OrderByYearDescending = orderByYearsDescending;
            OrderBySubjectDescending = orderBySubjectDescending;
        }

        public IEnumerable<string> GetReportHeader()
        {
            using (GetYearsSubjectsAverageGradeTable())
            {
                List<string> resultReportHeader = new List<string>();

                foreach (object value in GetYearsSubjectsAverageGradeTable().Columns)
                {
                    resultReportHeader.Add(value.ToString());
                }

                return resultReportHeader;
            }
        }

        public IEnumerable<IEnumerable<string>> GetReportTable()
        {
            using (GetYearsSubjectsAverageGradeTable())
            {
                List<List<string>> resultReportTable = new List<List<string>>();

                foreach (DataRow dataRow in GetYearsSubjectsAverageGradeTable().Rows)
                {
                    List<string> listDataRowStrings = new List<string>();
                    listDataRowStrings = dataRow.ItemArray.Cast<string>().ToList();
                    resultReportTable.Add(listDataRowStrings);
                }

                return resultReportTable;
            }
        }

        public DataTable GetYearsSubjectsAverageGradeTable()
        {
            List<int> allExamYears;
            if (OrderByYearDescending == false)
            {
                allExamYears = examDAO.ReadAll().Select(e => e.ExamDate.Year).Distinct().OrderBy(x => x).ToList();
            }
            else
            {
                allExamYears = examDAO.ReadAll().Select(e => e.ExamDate.Year).Distinct().ToList();
            }


            DataTable yearsSubjectsAverageGradeTable = new DataTable("YearsSubjectsAverageGradeTable");

            yearsSubjectsAverageGradeTable.Columns.Add("Subject");

            foreach (int year in allExamYears)
            {
                yearsSubjectsAverageGradeTable.Columns.Add(year.ToString());
            }


            IEnumerable<Subject> allExaminedSubjects = (from subject in subjectDAO.ReadAll()
                join exam in examDAO.ReadAll() on subject.Id equals exam.SubjectId
                select subject).Distinct();

            int index = 0;
            List<Exam> exams = examDAO.ReadAll();
            List<Result> results = resultDAO.ReadAll();

            foreach (Subject subject in allExaminedSubjects)
            {
                DataRow dataTableRow = yearsSubjectsAverageGradeTable.NewRow();
                dataTableRow[index] = subject.SubjectName;
                index++;

                foreach (int year in allExamYears)
                {
                    IEnumerable<Result> studentsGrades = from result in results
                        join exam in exams on result.ExamId equals exam.Id
                        join subj in allExaminedSubjects on exam.SubjectId equals subj.Id
                        where exam.ExamDate.Year == year & subj.Id == subject.Id
                        select result;

                    dataTableRow[index] = string.Format("{0:0.00}", studentsGrades.Average(s => s.StudentsGrade));
                    index++;
                }

                yearsSubjectsAverageGradeTable.Rows.Add(dataTableRow);
                index = 0;
            }


            if (OrderBySubjectDescending == false)
            {
                return yearsSubjectsAverageGradeTable;
            }
            else
            {
                return yearsSubjectsAverageGradeTable.AsEnumerable().OrderBy(s => s.Field<string>("Subject")).CopyToDataTable();
            }
        }
    }
}
