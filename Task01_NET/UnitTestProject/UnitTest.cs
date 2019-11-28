using System;
using Task01_NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    /// <summary>
    /// Testing units
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        // parametrs for calculating GCD 
        int first;
        int second;
        int third;
        int fourth;
        int fifth;
        // flag variable
        bool ok;
        // result GCD variable
        int result;
        // random object
        readonly Random random = new Random();

        /// <summary>
        /// Method for verifying GCD
        /// </summary>
        /// <param name="gcd">GCD for verification</param>
        /// <param name="numbers">Set of numbers for GCD verification</param>
        /// <returns>Result of verification (true or false)</returns>
        private bool VerifyGCD(int gcd, params int[] numbers)
        {
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % gcd == 0)
                {
                    counter++;
                }
            }

            if (counter == numbers.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Test method for EuclideanGCD method with two parameters
        /// </summary>
        [TestMethod]
        public void TestMethodForEuclideanGCDWithTwoParameters()
        {
            first = random.Next(-1000, 1000);       // first random input parametr
            second = random.Next(-1001, 1001);       // second random input parametr

            result = FindGCD.EuclideanGCD(first, second, out double time);   // result of GCD calculation

            if (VerifyGCD(result, first, second))                        // verifying result GCD
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            Assert.IsTrue(ok);                                  // if ok is true, then test passed
        }

        /// <summary>
        /// Test method for EuclideanGCD method with three parameters
        /// </summary>
        [TestMethod]
        public void TestMethodForEuclideanGCDWithThreeParameters()
        {
            first = random.Next(-1002, 1002);                       // first random input parametr
            second = random.Next(-1003, 1003);                       // second random input parametr
            third = random.Next(-1004, 1004);                       // third random input parametr

            result = FindGCD.EuclideanGCD(first, second, third);                 // result of GCD calculation

            if (VerifyGCD(result, first, second, third))                     // verifying result GCD
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            Assert.IsTrue(ok);                                  // if ok is true, then test passed
        }

        /// <summary>
        /// Test method for EuclideanGCD method with four parameters
        /// </summary>
        [TestMethod]
        public void TestMethodForEuclideanGCDWithFourParameters()
        {
            first = random.Next(-1005, 1005);                       // first random input parametr
            second = random.Next(-1006, 1006);                       // second random input parametr
            third = random.Next(-1007, 1007);                       // third random input parametr
            fourth = random.Next(-1008, 1008);                       // fourth random input parametr

            result = FindGCD.EuclideanGCD(first, second, third, fourth);              // result of GCD calculation

            if (VerifyGCD(result, first, second, third, fourth))                  // verifying result GCD
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            Assert.IsTrue(ok);                                  // if ok is true, then test passed
        }

        /// <summary>
        /// Test method for EuclideanGCD method with five parameters
        /// </summary>
        [TestMethod]
        public void TestMethodForEuclideanGCDWithFiveParameters()
        {
            first = random.Next(-1009, 1009);                       // first random input parametr
            second = random.Next(-1001, 1001);                       // second random input parametr
            third = random.Next(-1002, 1002);                       // third random input parametr
            fourth = random.Next(-1003, 1003);                       // fourth random input parametr
            fifth = random.Next(-1004, 1004);                       // fifth random input parametr

            result = FindGCD.EuclideanGCD(first, second, third, fourth, fifth);           // result of GCD calculation

            if (VerifyGCD(result, first, second, third, fourth, fifth))               // verifying result GCD
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            Assert.IsTrue(ok);                                  // if ok is true, then test passed
        }

        /// <summary>
        /// Test method for SteinGCD method with two parameters
        /// </summary>
        [TestMethod]
        public void TestMethodForSteinGCDWithTwoParameters()
        {
            first = random.Next(-1005, 1005);                       // first random input parametr
            second = random.Next(-1006, 1006);                       // second random input parametr

            result = FindGCD.SteinGCD(first, second, out double time);       // result of GCD calculation

            if (VerifyGCD(result, first, second))                        // verifying result GCD
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            Assert.IsTrue(ok);                                  // if ok is true, then test passed
        }
    }
}
