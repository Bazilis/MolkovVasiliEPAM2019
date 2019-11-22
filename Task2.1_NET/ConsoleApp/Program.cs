using System;
using ClassLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Vector first = new Vector(8, 6, 9);

            Vector second = new Vector(7, 5, 4);            

            Console.WriteLine(first.Length);

            Console.WriteLine(first + second);

            Console.WriteLine(first - second);

            Console.WriteLine(first * second);

            Console.WriteLine(first ^ second);

            Console.WriteLine(first * 7);

            Console.WriteLine(second / 2);

            Console.ReadKey();
        }
    }
}
