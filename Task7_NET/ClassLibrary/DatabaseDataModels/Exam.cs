using System;
using System.Data.Linq.Mapping;

namespace ConsoleApp.DatabaseDataModels
{
    [Table(Name = "Exam")]
    public class Exam
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "SessionNumber")]
        public int SessionNumber { get; set; }


        [Column(Name = "ExamDate")]
        public DateTime ExamDate { get; set; }


        [Column(Name = "GroupId")]
        public int GroupId { get; set; }


        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }


        [Column(Name = "ExaminerId")]
        public int ExaminerId { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Session number: {SessionNumber}, Exam date: {ExamDate}," +
                   $"Group Id: {GroupId}, Subject Id: {SubjectId}, Examiner Id: {ExaminerId}";
        }
    }
}
