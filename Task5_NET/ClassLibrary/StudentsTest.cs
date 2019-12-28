using System;

namespace ClassLibrary
{
    public class StudentsTest : IComparable
    {
        private string nameOfStudent;

        private int gradeOfStudent;

        private string topicOfTest;

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

        public override string ToString()
        {
            return $"Name of student-> {NameOfStudent}; grade of student-> {GradeOfStudent}; topic of test-> {TopicOfTest}; date of test-> {DateOfTest}";
        }
    }
}
