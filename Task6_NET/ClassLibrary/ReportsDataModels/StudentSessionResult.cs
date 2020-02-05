using System;

namespace ClassLibrary.ReportsDataModels
{
    public class StudentSessionResult
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }
        public DateTime ExamDate { get; set; }
        public double? StudentsGrade { get; set; }
    }
}
