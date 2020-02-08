using System;

namespace ClassLibrary.DatabaseDataModels
{
    /// <summary>
    /// Data model for Result database table
    /// </summary>
    public class Result
    {
        public int Id { get; private set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public double? StudentsGrade { get; set; }

        public Result(int id, int examId, int studentId, double? studentGrade)
        {
            Id = id;
            ExamId = examId;
            StudentId = studentId;
            StudentsGrade = studentGrade;
        }

        public Result(int examId, int studentId, double? studentGrade)
        {
            ExamId = examId;
            StudentId = studentId;
            StudentsGrade = studentGrade;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Exam Id: {ExamId}, Student Id: {StudentId}, Students grade: {StudentsGrade}";
        }
    }
}
