using System;
using System.Data.Linq.Mapping;

namespace ConsoleApp.DatabaseDataModels
{
    [Table(Name = "Examiner")]
    public class Examiner
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "ExaminerSurname")]
        public string ExaminerSurname { get; set; }


        [Column(Name = "ExaminerName")]
        public string ExaminerName { get; set; }


        [Column(Name = "ExaminerPatronymic")]
        public string ExaminerPatronymic { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Examiner surname: {ExaminerSurname}, Examiner name: {ExaminerName}, Examiner patronymic: {ExaminerPatronymic}";
        }
    }
}
