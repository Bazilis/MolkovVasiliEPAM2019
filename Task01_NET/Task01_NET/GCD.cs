using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Task01_NET
{
    public class GCD                            // Greatest Common Divisor
    {
        /// <summary>
        /// Euclidean algorithm method for two integers and
        /// output parameter for calculation time
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="elapsed_time">Calculation time in milliseconds</param>
        /// <returns>GCD of two integers and calculation time in milliseconds</returns>
        public static int EuclideanGCD(int a, int b, out double elapsed_time)
        {
            Stopwatch timer = new Stopwatch();  // create new stopwatch object
            timer.Start();                      // begin timing
            a = Math.Abs(a);                    // get absolute value for 'a' parameter
            b = Math.Abs(b);                    // get absolute value for 'b' parameter
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            timer.Stop();                   // stop timing
            elapsed_time = timer.Elapsed.TotalMilliseconds;   // output elapsed time
            return a;
        }

        /// <summary>
        /// Euclidean algorithm method for three integers
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <returns>GCD of three integers</returns>
        public static int EuclideanGCD(int a, int b, int c)
        {
            // recursive EuclideanGCD method call with void out parameters
            return EuclideanGCD(EuclideanGCD(a, b, out double time1), c, out double time2);
        }

        /// <summary>
        /// Euclidean algorithm method for four integers using recursion
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <param name="d">Fourth integer</param>
        /// <returns>GCD of four integers</returns>
        public static int EuclideanGCD(int a, int b, int c, int d)
        {
            // recursive EuclideanGCD method call with void out parameter
            return EuclideanGCD(EuclideanGCD(a, b, c), d, out double time);
        }

        /// <summary>
        /// Euclidean algorithm method for five integers using recursion
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="c">Third integer</param>
        /// <param name="d">Fourth integer</param>
        /// <param name="e">Fifth integer</param>
        /// <returns>GCD of five integers</returns>
        public static int EuclideanGCD(int a, int b, int c, int d, int e)
        {
            // recursive EuclideanGCD method call with void out parameter
            return EuclideanGCD(EuclideanGCD(a, b, c, d), e, out double time);
        }

        /// <summary>
        /// Stein's algorithm method for two integers and
        /// output parameter for calculation time
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <param name="elapsed_time">Calculation time in milliseconds</param>
        /// <returns>GCD of two integers and calculation time in milliseconds</returns>
        public static int SteinGCD(int a, int b, out double elapsed_time)
        {
            Stopwatch timer = new Stopwatch();          // create new stopwatch object
            timer.Start();                              // begin timing

            if (a == 0)
            {
                timer.Stop();                           // stop timing
                elapsed_time = timer.Elapsed.TotalMilliseconds;           // output elapsed time
                return Math.Abs(b);                     // GCD(0, b) = b
            }

            if (b == 0)
            {
                timer.Stop();                           // stop timing
                elapsed_time = timer.Elapsed.TotalMilliseconds;           // output elapsed time
                return Math.Abs(a);                     // GCD(a, 0) = a
            }

            if (a == b)
            {
                timer.Stop();                           // stop timing
                elapsed_time = timer.Elapsed.TotalMilliseconds;           // output elapsed time
                return Math.Abs(a);                     // GCD(a, a) = a
            }

            if (a == 1 || b == 1)
            {
                timer.Stop();                           // stop timing
                elapsed_time = timer.Elapsed.TotalMilliseconds;           // output elapsed time
                return 1;                               // GCD(1, b) = GCD(a, 1) = 1
            }

            int k = 1;                                  // binary disproportion counter
            a = Math.Abs(a);                            // get absolute value for 'a' parameter
            b = Math.Abs(b);                            // get absolute value for 'b' parameter
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))    // GCD(a, b) = 2 * GCD(a / 2, b / 2)
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;                             // double increase binary disproportion counter
                }
                while (a % 2 == 0) a /= 2;              // GCD(a, b) = GCD(a / 2, b)
                while (b % 2 == 0) b /= 2;              // GCD(a, b) = GCD(a, b / 2)
                if (a >= b)
                {
                    a -= b;                             // GCD(a, b) = GCD((a - b), b)
                }
                else
                {
                    b -= a;                             // GCD(a, b) = GCD(a, (b - a))
                }
            }
            timer.Stop();                               // stop timing
            elapsed_time = timer.Elapsed.TotalMilliseconds;               // output elapsed time
            return b * k;
        }

        /// <summary>
        /// Preparing data method for histogram plotting
        /// </summary>
        /// <param name="a">First integer for calculating GCD</param>
        /// <param name="b">Second integer for calculating GCD</param>
        /// <param name="euclidean_elapsed_time">Calculation time for Euclidean method</param>
        /// <param name="stein_elapsed_time">Calculation time for Stein's method</param>
        /// <returns>GCD of two integers and calculation time in milliseconds for both methods</returns>
        public static int CalculationTimeCompareData(int a, int b, out double euclidean_elapsed_time, out double stein_elapsed_time)
        {

            int gcd = EuclideanGCD(a, b, out double x);
            euclidean_elapsed_time = x;                     // return calculation time in milliseconds for Euclidean method

            SteinGCD(a, b, out double y);
            stein_elapsed_time =y;                          // return calculation time in milliseconds for Stein's method

            return gcd;                                     // return GCD
        }
    }
}
