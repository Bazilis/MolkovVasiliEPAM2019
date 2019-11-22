using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void AdditionOfVectorsOverloadedOperatorTestMethod()
        {
            Vector first = new Vector(8, 6, 9);         // first Vector type instance
            Vector second = new Vector(7, 5, 4);        // second Vector type instance

            Vector expected = new Vector(15, 11, 13);   // expected result of calculation


            Vector result = first + second;             // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare results
        }

        [TestMethod]
        public void SubtructionOfVectorsOverloadedOperatorTestMethod()
        {
            Vector first = new Vector(8, 6, 9);         // first Vector type instance
            Vector second = new Vector(7, 5, 4);        // second Vector type instance

            Vector expected = new Vector(1, 1, 5);      // expected result of calculation


            Vector result = first - second;             // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare results
        }

        [TestMethod]
        public void ScalarMultiplicationOfVectorsOverloadedOperatorTestMethod()
        {
            Vector first = new Vector(8, 6, 9);         // first Vector type instance
            Vector second = new Vector(7, 5, 4);        // second Vector type instance

            double expected = 122;                      // expected result of calculation


            double result = first * second;             // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare results
        }

        [TestMethod]
        public void VectorMultiplicationOfVectorsOverloadedOperatorTestMethod()
        {
            Vector first = new Vector(8, 6, 9);         // first Vector type instance
            Vector second = new Vector(7, 5, 4);        // second Vector type instance

            Vector expected = new Vector(-21, 31, -2);  // expected result of calculation


            Vector result = first ^ second;             // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare results
        }

        [TestMethod]
        public void VectorAndScalarMultiplicationOverloadedOperatorTestMethod()
        {
            Vector vector = new Vector(8, 6, 9);        // Vector type instance
            double scalar = 7;                          // double type scalar

            Vector expected = new Vector(56, 42, 63);   // expected result of calculation


            Vector result = vector * scalar;            // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare results
        }

        [TestMethod]
        public void VectorAndScalarDivisionOverloadedOperatorTestMethod()
        {
            Vector vector = new Vector(7, 5, 4);        // Vector type instance
            double scalar = 2;                          // double type scalar

            Vector expected = new Vector(3.5, 2.5, 2);  // expected result of calculation


            Vector result = vector / scalar;            // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare results
        }
    }
}
