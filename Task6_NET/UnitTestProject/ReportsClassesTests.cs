using System;
using System.Linq;
using ClassLibrary.Reports;
using System.Collections.Generic;
using ClassLibrary.DatabaseDataModels;
using ClassLibrary.DataAccessObjectsFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    /// <summary>
    /// Test methods for report classes
    /// </summary>
    [TestClass()]
    public class ReportsClassesTests
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Database;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

        DAOCreator creatorDAO = DAOCreator.GetInstance(connectionString);

        /// <summary>
        /// Test method for 'ExcludedStudentsList' class
        /// </summary>
        [TestMethod()]
        public void ExcludedStudentsListTestMethod()
        {
            ExcludedStudentsList excludedStudents = new ExcludedStudentsList(creatorDAO);

            Student expectedExcludedStudent = creatorDAO.GetStudentDAO().Read(3);


            Student resultExcludedStudent = null;
            List<IGrouping<int, Student>> excludedStudentsList = excludedStudents.GetExcludedStudentsList(55, 1);

            foreach (IGrouping<int, Student> groupingExcludedStudents in excludedStudentsList)
            {
                foreach (Student student in groupingExcludedStudents)
                {
                    resultExcludedStudent = new Student(student.Id, student.Surname, student.Name, student.Patronymic, student.Gender, student.DateOfBirth, student.GroupId);
                }
            }




            Assert.IsTrue(expectedExcludedStudent == resultExcludedStudent);
        }

        /// <summary>
        /// Test method for 'ForEachGroupSessionsResults' class
        /// </summary>
        [TestMethod()]
        public void ForEachGroupSessionsResultsReportTestMethod()
        {
            ForEachGroupSessionsResults groupSessionResultsReport = new ForEachGroupSessionsResults(creatorDAO: creatorDAO,
                sessionNumber: 3, orderBy: s => s.GroupName, orderByDescending: false);

            string expectedString = "3" + "IT32" + "Livshits" + "Valeriy" + "Erofeevich" + "Male" + "01.08.2000" +
                                    "History" + "Credit" + "01.02.2005" + "80,00";


            string resultString = string.Empty;
            IEnumerable<IEnumerable<IEnumerable<string>>> reportTables = groupSessionResultsReport.GetReportTables();

            foreach (IEnumerable<IEnumerable<string>> table in reportTables)
            {
                foreach (IEnumerable<string> list in table)
                {
                    foreach (string str in list)
                    {
                        resultString += str;
                    }
                }
            }


            ExportToXlsx.ToXlsxFile(groupSessionResultsReport, "C:\\Users\\Asus\\source\\repos\\MolkovVasiliEPAM2019\\Task6_NET\\UnitTestProject\\", "GroupSessionResultsReport");

            Assert.IsTrue(resultString == expectedString);
        }

        /// <summary>
        /// Test method for 'ForEachSessionGroupsGradesResults' class
        /// </summary>
        [TestMethod()]
        public void ForEachSessionGroupsGradesResultsTestMethod()
        {
            ForEachSessionGroupsGradesResults sessionGroupsGradesResults = new ForEachSessionGroupsGradesResults(creatorDAO: creatorDAO,
                orderBy: s => s.GroupName, orderByDescending: false);


            string expectedString = "IT31" + "50,00" + "50,00" + "50,00" +
                                    "IT32" + "90,00" + "90,00" + "90,00" +
                                    "IT33" + "80,00" + "80,00" + "80,00";



            string resultString = string.Empty;
            IEnumerable<IEnumerable<IEnumerable<string>>> reportTables = sessionGroupsGradesResults.GetReportTables();

            foreach (IEnumerable<IEnumerable<string>> table in reportTables)
            {
                foreach (IEnumerable<string> list in table)
                {
                    foreach (string str in list)
                    {
                        resultString += str;
                    }
                }
            }


            ExportToXlsx.ToXlsxFile(sessionGroupsGradesResults, "C:\\Users\\Asus\\source\\repos\\MolkovVasiliEPAM2019\\Task6_NET\\UnitTestProject\\", "SessionGroupsGradesResultsReport");

            Assert.IsTrue(resultString == expectedString);
        }

    }
}
