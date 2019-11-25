using ClassLibrary;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MonomUnitTest
    {
        [TestMethod]
        public void MultiplicationOfMonomsOverloadedOperatorTestMethod()
        {
            Monom first = new Monom(3, 2);      // first Monom type instance
            Monom second = new Monom(4, 3);     // second Monom type instance

            Monom expected = new Monom(12, 5);  // expected result of calculation


            Monom result = first * second;      // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);  // compare result
        }

        [TestMethod()]
        public void DivisionOfMonomsOverloadedOperatorTestMethod()
        {
            Monom first = new Monom(3, 2);          // first Monom type instance
            Monom second = new Monom(4, 3);         // second Monom type instance

            Monom expected = new Monom(0.75, -1);   // expected result of calculation


            Monom result = first / second;          // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);      // compare result
        }

        [TestMethod]
        public void MultiplicationMonomTypeOnDoubleTypeOverloadedOperatorTestMethod()
        {
            Monom monom = new Monom(3, 2);          // Monom type instance
            double number = 3;                      // double type number

            Monom expected = new Monom(9, 2);       // expected result of calculation


            Monom result = monom * number;          // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);      // compare result
        }

        [TestMethod]
        public void DivisionMonomTypeOnDoubleTypeOverloadedOperatorTestMethod()
        {
            Monom monom = new Monom(3, 2);          // Monom type instance
            double number = 4;                      // double type number

            Monom expected = new Monom(0.75, 2);    // expected result of calculation


            Monom result = monom / number;          // result of calculation using overloaded operator


            Assert.AreEqual(expected, result);      // compare result
        }

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