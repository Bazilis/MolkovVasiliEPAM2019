using System;
using System.Data.Linq.Mapping;

namespace ConsoleApp.DatabaseDataModels
{
    [Table(Name = "Student")]
    public class Student
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "Surname")]
        public string Surname { get; set; }


        [Column(Name = "Name")]
        public string Name { get; set; }


        [Column(Name = "Patronymic")]
        public string Patronymic { get; set; }


        [Column(Name = "Gender")]
        public string Gender { get; set; }


        [Column(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }


        [Column(Name = "GroupId")]
        public int GroupId { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Surname: {Surname}, Name: {Name}, Patronymic: {Patronymic}," +
                   $"Gender: {Gender}, Date of birth: {DateOfBirth}, Group Id: {GroupId}";
        }
    }
}
