using System;
using Task01_NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        // parametrs for calculating GCD 
        int a;
        int b;
        int c;
        int d;
        int e;
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
            a = random.Next(-1000, 1000);       // first random input parametr
            b = random.Next(-1001, 1001);       // second random input parametr

            result = GCD.EuclideanGCD(a, b, out double time);   // result of GCD calculation

            if (VerifyGCD(result, a, b))                        // verifying result GCD
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
            a = random.Next(-1002, 1002);                       // first random input parametr
            b = random.Next(-1003, 1003);                       // second random input parametr
            c = random.Next(-1004, 1004);                       // third random input parametr

            result = GCD.EuclideanGCD(a, b, c);                 // result of GCD calculation

            if (VerifyGCD(result, a, b, c))                     // verifying result GCD
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
            a = random.Next(-1005, 1005);                       // first random input parametr
            b = random.Next(-1006, 1006);                       // second random input parametr
            c = random.Next(-1007, 1007);                       // third random input parametr
            d = random.Next(-1008, 1008);                       // fourth random input parametr

            result = GCD.EuclideanGCD(a, b, c, d);              // result of GCD calculation

            if (VerifyGCD(result, a, b, c, d))                  // verifying result GCD
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
            a = random.Next(-1009, 1009);                       // first random input parametr
            b = random.Next(-1001, 1001);                       // second random input parametr
            c = random.Next(-1002, 1002);                       // third random input parametr
            d = random.Next(-1003, 1003);                       // fourth random input parametr
            e = random.Next(-1004, 1004);                       // fifth random input parametr

            result = GCD.EuclideanGCD(a, b, c, d, e);           // result of GCD calculation

            if (VerifyGCD(result, a, b, c, d, e))               // verifying result GCD
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
            a = random.Next(-1005, 1005);                       // first random input parametr
            b = random.Next(-1006, 1006);                       // second random input parametr

            result = GCD.SteinGCD(a, b, out double time);       // result of GCD calculation

            if (VerifyGCD(result, a, b))                        // verifying result GCD
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
