using System;
using System.Data.Linq.Mapping;

namespace ConsoleApp.DatabaseDataModels
{
    [Table(Name = "Subject")]
    public class Subject
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }


        [Column(Name = "SubjectType")]
        public string SubjectType { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Subject name: {SubjectName}, Subject type: {SubjectType}";
        }
    }
}
