using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Class containing information about student's test
    /// </summary>
    [DataContract(IsReference = true)]
    public class StudentsTest : IComparable
    {
        private string nameOfStudent;

        private int gradeOfStudent;

        private string topicOfTest;

        /// <summary>
        /// Name of student property
        /// </summary>
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

        /// <summary>
        /// Grade of student property
        /// </summary>
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

        /// <summary>
        /// Topic of test property
        /// </summary>
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

        /// <summary>
        /// Date of test property
        /// </summary>
        [DataMember]
        public DateTime DateOfTest { get; private set; }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="nameOfStudent"></param>
        /// <param name="gradeOfStudent"></param>
        /// <param name="topicOfTest"></param>
        /// <param name="dateOfTest"></param>
        public StudentsTest(string nameOfStudent, int gradeOfStudent, string topicOfTest, DateTime dateOfTest)
        {
            NameOfStudent = nameOfStudent;
            GradeOfStudent = gradeOfStudent;
            TopicOfTest = topicOfTest;
            DateOfTest = dateOfTest;
        }

        /// <summary>
        /// Implementation of method for comparing objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Overload comparison operator '=='
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator ==(StudentsTest first, StudentsTest second)
        {
            return first.NameOfStudent == second.NameOfStudent && first.GradeOfStudent == second.GradeOfStudent &&
                   first.TopicOfTest == second.TopicOfTest && first.DateOfTest == second.DateOfTest;
        }

        /// <summary>
        /// Overload comparison operator '!='
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator !=(StudentsTest first, StudentsTest second)
        {
            return first.NameOfStudent != second.NameOfStudent || first.GradeOfStudent != second.GradeOfStudent ||
                   first.TopicOfTest != second.TopicOfTest || first.DateOfTest != second.DateOfTest;
        }

        /// <summary>
        /// Override Equals() method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Override GetHashCode() method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (NameOfStudent.Length + GradeOfStudent + TopicOfTest.Length).GetHashCode();
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Name of student-> {NameOfStudent}; grade of student-> {GradeOfStudent}; topic of test-> {TopicOfTest}; date of test-> {DateOfTest}";
        }
    }
}
