using System;

namespace Task01_NET
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter two integers");

            int x = Convert.ToInt32(Console.ReadLine());

            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} {1}", GCD.EuclideanGCD(x, y, out TimeSpan n), n);

            Console.WriteLine("{0} {1}", GCD.SteinGCD(x, y, out TimeSpan m), m);

            Console.ReadLine();
        }
    }
}
