using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Task01_NET
{
    /// <summary>
    /// Find Greatest Common Divisor
    /// </summary>
    public class FindGCD
    {
        /// <summary>
        /// Euclidean algorithm method for two integers and
        /// output parameter for calculation time
        /// </summary>
        /// <param name="first">First integer</param>
        /// <param name="second">Second integer</param>
        /// <param name="elapsed_time">Calculation time in milliseconds</param>
        /// <returns>GCD of two integers and calculation time in milliseconds</returns>
        public static int EuclideanGCD(int first, int second, out double elapsed_time)
        {
            Stopwatch timer = new Stopwatch();  // create new stopwatch object
            timer.Start();                      // begin timing
            first = Math.Abs(first);            // get absolute value for first parameter
            second = Math.Abs(second);          // get absolute value for second parameter
            while (first != second)
            {
                if (first > second)
                {
                    first -= second;
                }
                else
                {
                    second -= first;
                }
            }
            timer.Stop();                       // stop timing
            elapsed_time = timer.Elapsed.TotalMilliseconds;   // output elapsed time
            return first;
        }

        /// <summary>
        /// Euclidean algorithm method for three integers
        /// </summary>
        /// <param name="first">First integer</param>
        /// <param name="second">Second integer</param>
        /// <param name="third">Third integer</param>
        /// <returns>GCD of three integers</returns>
        public static int EuclideanGCD(int first, int second, int third)
        {
            // recursive EuclideanGCD method call with void out parameters
            return EuclideanGCD(EuclideanGCD(first, second, out double time1), third, out double time2);
        }

        /// <summary>
        /// Euclidean algorithm method for four integers using recursion
        /// </summary>
        /// <param name="first">First integer</param>
        /// <param name="second">Second integer</param>
        /// <param name="third">Third integer</param>
        /// <param name="fourth">Fourth integer</param>
        /// <returns>GCD of four integers</returns>
        public static int EuclideanGCD(int first, int second, int third, int fourth)
        {
            // recursive EuclideanGCD method call with void out parameter
            return EuclideanGCD(EuclideanGCD(first, second, third), fourth, out double time);
        }

        /// <summary>
        /// Euclidean algorithm method for five integers using recursion
        /// </summary>
        /// <param name="first">First integer</param>
        /// <param name="second">Second integer</param>
        /// <param name="third">Third integer</param>
        /// <param name="fourth">Fourth integer</param>
        /// <param name="fifth">Fifth integer</param>
        /// <returns>GCD of five integers</returns>
        public static int EuclideanGCD(int first, int second, int third, int fourth, int fifth)
        {
            // recursive EuclideanGCD method call with void out parameter
            return EuclideanGCD(EuclideanGCD(first, second, third, fourth), fifth, out double time);
        }

        /// <summary>
        /// Stein's algorithm method for two integers and
        /// output parameter for calculation time
        /// </summary>
        /// <param name="first">First integer</param>
        /// <param name="second">Second integer</param>
        /// <param name="elapsed_time">Calculation time in milliseconds</param>
        /// <returns>GCD of two integers and calculation time in milliseconds</returns>
        public static int SteinGCD(int first, int second, out double elapsed_time)
        {
            Stopwatch timer = new Stopwatch();          // create new stopwatch object
            timer.Start();                              // begin timing

            if (first == 0)
            {
                timer.Stop();                           // stop timing
                elapsed_time = timer.Elapsed.TotalMilliseconds;           // output elapsed time
                return Math.Abs(second);                     // GCD(0, b) = b
            }

            if (second == 0)
            {
                timer.Stop();                           // stop timing
                elapsed_time = timer.Elapsed.TotalMilliseconds;           // output elapsed time
                return Math.Abs(first);                     // GCD(a, 0) = a
            }

            if (first == second)
            {
                timer.Stop();                           // stop timing
                elapsed_time = timer.Elapsed.TotalMilliseconds;           // output elapsed time
                return Math.Abs(first);                     // GCD(a, a) = a
            }

            if (first == 1 || second == 1)
            {
                timer.Stop();                           // stop timing
                elapsed_time = timer.Elapsed.TotalMilliseconds;           // output elapsed time
                return 1;                               // GCD(1, b) = GCD(a, 1) = 1
            }

            int k = 1;                                  // binary disproportion counter
            first = Math.Abs(first);                            // get absolute value for 'a' parameter
            second = Math.Abs(second);                            // get absolute value for 'b' parameter
            while ((first != 0) && (second != 0))
            {
                while ((first % 2 == 0) && (second % 2 == 0))    // GCD(a, b) = 2 * GCD(a / 2, b / 2)
                {
                    first /= 2;
                    second /= 2;
                    k *= 2;                             // double increase binary disproportion counter
                }
                while (first % 2 == 0) first /= 2;              // GCD(a, b) = GCD(a / 2, b)
                while (second % 2 == 0) second /= 2;              // GCD(a, b) = GCD(a, b / 2)
                if (first >= second)
                {
                    first -= second;                             // GCD(a, b) = GCD((a - b), b)
                }
                else
                {
                    second -= first;                             // GCD(a, b) = GCD(a, (b - a))
                }
            }
            timer.Stop();                               // stop timing
            elapsed_time = timer.Elapsed.TotalMilliseconds;               // output elapsed time
            return second * k;
        }

        /// <summary>
        /// Preparing data method for histogram plotting
        /// </summary>
        /// <param name="first">First integer for calculating GCD</param>
        /// <param name="second">Second integer for calculating GCD</param>
        /// <param name="euclidean_elapsed_time">Calculation time for Euclidean method</param>
        /// <param name="stein_elapsed_time">Calculation time for Stein's method</param>
        /// <returns>GCD of two integers and calculation time in milliseconds for both methods</returns>
        public static int CalculationTimeCompareData(int first, int second, out double euclidean_elapsed_time, out double stein_elapsed_time)
        {

            int gcd = EuclideanGCD(first, second, out double x);
            euclidean_elapsed_time = x;                     // return calculation time in milliseconds for Euclidean method

            SteinGCD(first, second, out double y);
            stein_elapsed_time = y;                         // return calculation time in milliseconds for Stein's method

            return gcd;                                     // return GCD
        }
    }
}
