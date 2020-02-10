using System;

namespace ConsoleApp.ReportsDataModels
{
    public class ExaminerAverageGradeResult
    {
        public string ExaminerSurname { get; set; }

        public string ExaminerName { get; set; }

        public string ExaminerPatronymic { get; set; }

        public double? ExaminerAverageGrade { get; set; }
    }
}
