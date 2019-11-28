using ClassLibrary;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    /// <summary>
    /// Class for testing Monom type units
    /// </summary>
    [TestClass]
    public class MonomUnitTest
    {
        /// <summary>
        /// Test method for '*' multiplication overloaded operator for two Monom types
        /// </summary>
        [TestMethod]
        public void MultiplicationOfMonomsOverloadedOperatorTestMethod()
        {
            Monom first = new Monom(3, 2);      // first Monom type instance
            Monom second = new Monom(4, 3);     // second Monom type instance

            Monom expected = new Monom(12, 5);  // expected result of calculation


            Monom result = first * second;      // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);  // compare result
        }

        /// <summary>
        /// Test method for '/' division overloaded operator for two Monom types
        /// </summary>
        [TestMethod()]
        public void DivisionOfMonomsOverloadedOperatorTestMethod()
        {
            Monom first = new Monom(3, 2);          // first Monom type instance
            Monom second = new Monom(4, 3);         // second Monom type instance

            Monom expected = new Monom(0.75, -1);   // expected result of calculation


            Monom result = first / second;          // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);      // compare result
        }

        /// <summary>
        /// Test method for '*' Monom and number multiplication overloaded operator
        /// </summary>
        [TestMethod]
        public void MultiplicationMonomTypeOnDoubleTypeOverloadedOperatorTestMethod()
        {
            Monom monom = new Monom(3, 2);          // Monom type instance
            double number = 3;                      // double type number

            Monom expected = new Monom(9, 2);       // expected result of calculation


            Monom result = monom * number;          // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);      // compare result
        }

        /// <summary>
        /// Test method for '/' Monom and number division overloaded operator
        /// </summary>
        [TestMethod]
        public void DivisionMonomTypeOnDoubleTypeOverloadedOperatorTestMethod()
        {
            Monom monom = new Monom(3, 2);          // Monom type instance
            double number = 4;                      // double type number

            Monom expected = new Monom(0.75, 2);    // expected result of calculation


            Monom result = monom / number;          // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);      // compare result
        }

        /// <summary>
        /// Test method for '+' addition overloaded operator for two Monom types
        /// </summary>
        [TestMethod]
        public void AdditionOfMonomsTypesOverloadedOperatorTestMethod()
        {
            Monom first = new Monom(3, 2);          // first Monom type instance
            Monom second = new Monom(4, 3);         // second Monom type instance

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(3, 2),
                new Monom(4, 3)
            });


            Polynom result = first + second;        // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);      // compare result
        }

        /// <summary>
        /// Test method for '-' subtraction overloaded operator for two Monom types
        /// </summary>
        [TestMethod]
        public void SubtructionOfMonomsTypesOverloadedOperatorTestMethod()
        {
            Monom first = new Monom(3, 2);          // first Monom type instance
            Monom second = new Monom(4, 3);         // second Monom type instance

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(3, 2),
                new Monom(-4, 3)
            });


            Polynom result = first - second;        // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);      // compare result
        }

        /// <summary>
        /// Test method for overrided Equals() method two Monom types
        /// </summary>
        [TestMethod]
        public void MonomsEqualsOverridedMethodTestMethod()
        {
            Monom first = new Monom(3, 2);          // first Monom type instance
            Monom second = new Monom(3, 2);         // second Monom type instance

            bool expected = true;                   // expected compare result


            bool result = first.Equals(second);     // compare result using overrided method


            Assert.AreEqual(expected, result);      // compare result
        }
    }
}
