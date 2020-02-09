using System;
using System.Data.Linq.Mapping;

namespace ConsoleApp.DatabaseDataModels
{
    [Table(Name = "Specialty")]
    public class Specialty
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "SpecialtyCode")]
        public string SpecialtyCode { get; set; }


        [Column(Name = "SpecialtyName")]
        public string SpecialtyName { get; set; }


        [Column(Name = "SpecialtyDescribe")]
        public string SpecialtyDescribe { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Specialty code: {SpecialtyCode}, Specialty name: {SpecialtyName}, Specialty describe: {SpecialtyDescribe}";
        }
    }
}
