using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [DataContract(IsReference = true)]
    public class StudentsTest : IComparable
    {
        private string nameOfStudent;

        private int gradeOfStudent;

        private string topicOfTest;

        [DataMember]
        public string NameOfStudent
        {
            get
            {
                return nameOfStudent;
            }
            private set
            {
                if (value.Length < 1)
                    throw new ArgumentException("Name of student is empty");

                else
                    nameOfStudent = value;
            }
        }

        [DataMember]
        public int GradeOfStudent
        {
            get
            {
                return gradeOfStudent;
            }
            private set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentException("Grade of student is out of range. It should be from 1 to 10 points");

                else
                    gradeOfStudent = value;
            }
        }

        [DataMember]
        public string TopicOfTest
        {
            get
            {
                return topicOfTest;
            }
            private set
            {
                if (value.Length < 1)
                    throw new ArgumentException("Topic of test is empty");

                else
                    topicOfTest = value;
            }
        }

        [DataMember]
        public DateTime DateOfTest { get; private set; }

        public StudentsTest(string nameOfStudent, int gradeOfStudent, string topicOfTest, DateTime dateOfTest)
        {
            NameOfStudent = nameOfStudent;
            GradeOfStudent = gradeOfStudent;
            TopicOfTest = topicOfTest;
            DateOfTest = dateOfTest;
        }

        public int CompareTo(object obj)
        {
            if (obj is StudentsTest student)
            {
                return GradeOfStudent.CompareTo(student.GradeOfStudent);
            }
            else
            {
                throw new ArgumentException("Impossible to compare");
            }
        }

        public static bool operator ==(StudentsTest first, StudentsTest second)
        {
            return first.NameOfStudent == second.NameOfStudent && first.GradeOfStudent == second.GradeOfStudent &&
                   first.TopicOfTest == second.TopicOfTest && first.DateOfTest == second.DateOfTest;
        }

        public static bool operator !=(StudentsTest first, StudentsTest second)
        {
            return first.NameOfStudent != second.NameOfStudent || first.GradeOfStudent != second.GradeOfStudent ||
                   first.TopicOfTest != second.TopicOfTest || first.DateOfTest != second.DateOfTest;
        }

        public override bool Equals(object obj)
        {
            if (obj is StudentsTest student)
                return (this.NameOfStudent == student.NameOfStudent &&
                        this.GradeOfStudent == student.GradeOfStudent &&
                        this.TopicOfTest == student.TopicOfTest &&
                        this.DateOfTest == student.DateOfTest);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (NameOfStudent.Length + GradeOfStudent + TopicOfTest.Length).GetHashCode();
        }

        public override string ToString()
        {
            return $"Name of student-> {NameOfStudent}; grade of student-> {GradeOfStudent}; topic of test-> {TopicOfTest}; date of test-> {DateOfTest}";
        }
    }
}
