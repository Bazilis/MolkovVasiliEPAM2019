using ClassLibrary;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    /// <summary>
    /// Class for testing Polynom type units
    /// </summary>
    [TestClass]
    public class PolynomUnitTest
    {
        /// <summary>
        /// Test method for '+' Polynom and Monom addition overloaded operator
        /// </summary>
        [TestMethod]
        public void AdditionOfPolynomAndMonomTypesOverloadedOperatorTestMethod()
        {
            Polynom polynom = new Polynom(new List<Monom>()     // Polynom type instance
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            Monom monom = new Monom(5, 2);                      // Monom type instance

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(8, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });


            Polynom result = polynom + monom;           // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare result
        }

        /// <summary>
        /// Test method for '-' Polynom and Monom subtraction overloaded operator
        /// </summary>
        [TestMethod]
        public void SubtructionOfPolynomAndMonomTypesOverloadedOperatorTestMethod()
        {
            Polynom polynom = new Polynom(new List<Monom>()     // Polynom type instance
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            Monom monom = new Monom(3, 2);                      // Monom type instance

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(6, 4),
                new Monom(4, 3)
            });


            Polynom result = polynom - monom;           // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare result
        }

        /// <summary>
        /// Test method for '+' addition overloaded operator for two Polynom types
        /// </summary>
        [TestMethod]
        public void AdditionOfPolynomTypesOverloadedOperatorTestMethod()
        {
            Polynom first = new Polynom(new List<Monom>()       // first Polynom type instance
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            Polynom second = new Polynom(new List<Monom>()      // second Polynom type instance
            {
                new Monom(4, 2),
                new Monom(2, 5)
            });

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(7, 2),
                new Monom(6, 4),
                new Monom(4, 3),
                new Monom(2, 5)
            });


            Polynom result = first + second;            // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare result
        }

        /// <summary>
        /// Test method for '-' subtraction overloaded operator for two Polynom types
        /// </summary>
        [TestMethod]
        public void SubtructionOfPolynomTypesOverloadedOperatorTestMethod()
        {
            Polynom first = new Polynom(new List<Monom>()       // first Polynom type instance
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            Polynom second = new Polynom(new List<Monom>()      // second Polynom type instance
            {
                new Monom(4, 2),
                new Monom(2, 5)
            });

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(-1, 2),
                new Monom(6, 4),
                new Monom(4, 3),
                new Monom(-2, 5)
            });


            Polynom result = first - second;            // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare result
        }

        /// <summary>
        /// Test method for '*' multiplication overloaded operator for two Polynom types
        /// </summary>
        [TestMethod]
        public void MultiplicationPolynomTypeOnDoubleTypeOverloadedOperatorTestMethod()
        {
            Polynom polynom = new Polynom(new List<Monom>()     // Polynom type instance
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            double number = 3;                                  // double type number

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(9, 2),
                new Monom(18, 4),
                new Monom(12, 3)
            });


            Polynom result = polynom * number;          // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare result
        }

        /// <summary>
        /// Test method for '/' Polynom and number division overloaded operator
        /// </summary>
        [TestMethod]
        public void DivisionPolynomTypeOnDoubleTypeOverloadedOperatorTestMethod()
        {
            Polynom polynom = new Polynom(new List<Monom>()     // Polynom type instance
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            double number = 4;                                  // double type number

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(0.75, 2),
                new Monom(1.5, 4),
                new Monom(1, 3)
            });


            Polynom result = polynom / number;          // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare result
        }

        /// <summary>
        /// Test method for '*' Polynom and Monom multiplication overloaded operator
        /// </summary>
        [TestMethod]
        public void MultiplicationOfPolynomAndMonomTypesOverloadedOperatorTestMethod()
        {
            Polynom polynom = new Polynom(new List<Monom>()     // Polynom type instance
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            Monom monom = new Monom(5, 3);                      // Monom type instance

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(15, 5),
                new Monom(30, 7),
                new Monom(20, 6)
            });


            Polynom result = polynom * monom;           // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare result
        }

        /// <summary>
        /// Test method for '*' multiplication overloaded operator for two Polynom types
        /// </summary>
        [TestMethod]
        public void MultiplicationOfPolynomTypesOverloadedOperatorTestMethod()
        {
            Polynom first = new Polynom(new List<Monom>()       // first Polynom type instance
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            Polynom second = new Polynom(new List<Monom>()      // second Polynom type instance
            {
                new Monom(2, 3),
                new Monom(3, 4)
            });

            Polynom expected = new Polynom(new List<Monom>()    // expected result of calculation
            {
                new Monom(6, 5),
                new Monom(17, 6),
                new Monom(24, 7),
                new Monom(18, 8)
            });


            Polynom result = first * second;            // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);          // compare result
        }

        /// <summary>
        /// Test method for overrided Equals() method for two Polynom types
        /// </summary>
        [TestMethod]
        public void PolynomialTestEquals()
        {
            Polynom first = new Polynom(new List<Monom>()   // first Polynom type instance
            {
                new Monom(5, 3),
                new Monom(2, 2),
                new Monom(2, 1)
            });

            Polynom second = new Polynom(new List<Monom>()  // second Polynom type instance
            {
                new Monom(2, 2),
                new Monom(5, 3),
                new Monom(2, 1)
            });

            bool expected = true;                   // expected compare result


            bool result = first.Equals(second);     // compare result using overrided method


            Assert.AreEqual(expected, result);      // compare result
        }
    }
}
