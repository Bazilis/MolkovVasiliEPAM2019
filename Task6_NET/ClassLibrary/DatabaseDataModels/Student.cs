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

        public static bool operator ==(Student first, Student second)
        {
            return first.Id == second.Id && first.Surname == second.Surname &&
                   first.Name == second.Name && first.Patronymic == second.Patronymic &&
                   first.Gender == second.Gender && first.DateOfBirth == second.DateOfBirth &&
                   first.GroupId == second.GroupId;
        }

        public static bool operator !=(Student first, Student second)
        {
            return first.Id != second.Id || first.Surname != second.Surname ||
                   first.Name != second.Name || first.Patronymic != second.Patronymic ||
                   first.Gender != second.Gender || first.DateOfBirth != second.DateOfBirth ||
                   first.GroupId != second.GroupId;
        }

        public override bool Equals(object obj)
        {
            if (obj is Student s)
                return (this.Id == s.Id && this.Surname == s.Surname &&
                        this.Name == s.Name && this.Patronymic == s.Patronymic &&
                        this.Gender == s.Gender && this.DateOfBirth == s.DateOfBirth &&
                        this.GroupId == s.GroupId);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (Id + Surname.Length + Name.Length + Patronymic.Length +
                    Gender.Length + DateOfBirth.ToString().Length +
                    GroupId).GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Surname: {Surname}, Name: {Name}, Patronymic: {Patronymic}, Gender: {Gender}, Date of birth: {DateOfBirth}, Group Id: {GroupId}";
        }
    }
}
