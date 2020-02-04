using System;

namespace ClassLibrary.DatabaseDataModels
{
    public class Student
    {
        public int Id { get; private set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GroupId { get; set; }

        public Student(int id, string surname, string name, string patronymic,
            string gender, DateTime dateOfBirth, int groupId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            GroupId = groupId;
        }

        public Student(string surname, string name, string patronymic,
            string gender, DateTime dateOfBirth, int groupId)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            GroupId = groupId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Surname: {Surname}, Name: {Name}, Patronymic: {Patronymic}, Gender: {Gender}, Date of birth: {DateOfBirth}, Group Id: {GroupId}";
        }
    }
}
