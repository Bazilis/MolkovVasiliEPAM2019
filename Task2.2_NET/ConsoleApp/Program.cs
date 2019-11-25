using System;
using ClassLibrary;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Polynom first = new Polynom(new List<Monom>()
            {
                new Monom(3, 2),
                new Monom(6, 4),
                new Monom(4, 3)
            });

            Polynom second = new Polynom(new List<Monom>()
            {
                new Monom(2, 3),
                new Monom(3, 4)
            });

            Console.WriteLine(first * second);

            Console.ReadKey();
        }
    }
}
