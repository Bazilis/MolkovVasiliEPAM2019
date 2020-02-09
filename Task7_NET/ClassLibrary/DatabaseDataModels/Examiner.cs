using System;
using System.Data.Linq.Mapping;

namespace ConsoleApp.DatabaseDataModels
{
    [Table(Name = "Examiner")]
    public class Examiner
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "Surname")]
        public string Surname { get; set; }


        [Column(Name = "Name")]
        public string Name { get; set; }


        [Column(Name = "Patronymic")]
        public string Patronymic { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Surname: {Surname}, Name: {Name}, Patronymic: {Patronymic}";
        }
    }
}
