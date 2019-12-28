using System;

namespace ClassLibrary
{
    public class StudentsTest : IComparable<StudentsTest>
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
            set
            {
                if (nameOfStudent.Length < 1)
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
            set
            {
                if (gradeOfStudent < 1 || gradeOfStudent > 10)
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
            set
            {
                if (topicOfTest.Length < 1)
                    throw new ArgumentException("Topic of test is empty");

                else
                    topicOfTest = value;
            }
        }

        public DateTime DateOfTest { get; private set; }

        public StudentsTest(string nameOfStudent, int markOfStudent, string topicOfTest, DateTime dateOfTest)
        {
            NameOfStudent = nameOfStudent;
            GradeOfStudent = markOfStudent;
            TopicOfTest = topicOfTest;
            DateOfTest = dateOfTest;
        }

        public int CompareTo(StudentsTest student)
        {
            if (student != null)
                return GradeOfStudent.CompareTo(student.GradeOfStudent);
            else
                throw new ArgumentException("Impossible to compare");
        }

        public override string ToString()
        {
            return $"Name of student-> {NameOfStudent}; grade of student-> {GradeOfStudent}; topic of test-> {TopicOfTest}; date of test-> {DateOfTest}";
        }
    }
}
