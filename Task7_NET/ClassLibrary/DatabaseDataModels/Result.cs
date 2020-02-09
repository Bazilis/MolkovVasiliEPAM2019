using System;
using System.Data.Linq.Mapping;

namespace ConsoleApp.DatabaseDataModels
{
    [Table(Name = "Result")]
    public class Result
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "ExamId")]
        public int ExamId { get; set; }


        [Column(Name = "StudentId")]
        public int StudentId { get; set; }


        [Column(Name = "StudentsGrade", CanBeNull = true)]
        public double? StudentsGrade { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Exam Id: {ExamId}, Student Id: {StudentId}, Student's grade: {StudentsGrade}";
        }
    }
}
