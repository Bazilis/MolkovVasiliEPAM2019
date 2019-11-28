using System;

namespace Task01_NET
{
    class Program
    {
        static void Main()  //just for simple tests
        {
            Console.WriteLine("Enter two integers");

            int a = Convert.ToInt32(Console.ReadLine());

            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} {1} {2}", FindGCD.CalculationTimeCompareData(a, b, out double x, out double y), x, y);

            Console.ReadLine();
        }
    }
}
