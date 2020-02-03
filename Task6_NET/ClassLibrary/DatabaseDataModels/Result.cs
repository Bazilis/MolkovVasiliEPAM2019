using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DatabaseDataModels
{
    public class Result
    {
        public int Id { get; private set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public double? StudentsGrade { get; set; }

        public Result(int id, int studentId, int examId, double? studentGrade)
        {
            Id = id;
            StudentId = studentId;
            ExamId = examId;
            StudentsGrade = studentGrade;
        }

        public Result(int studentId, int examId, double? studentGrade)
        {
            StudentId = studentId;
            ExamId = examId;
            StudentsGrade = studentGrade;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Student Id: {StudentId}, Exam Id: {ExamId}, Students grade: {StudentsGrade}";
        }
    }
}
