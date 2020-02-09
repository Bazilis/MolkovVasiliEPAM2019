using System;
using System.Data.Linq.Mapping;

namespace ConsoleApp.DatabaseDataModels
{
    [Table(Name = "Group")]
    public class Group
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "GroupName")]
        public string GroupName { get; set; }


        [Column(Name = "SpecialtyId")]
        public int SpecialtyId { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Group name: {GroupName}, Specialty Id: {SpecialtyId}";
        }
    }
}
