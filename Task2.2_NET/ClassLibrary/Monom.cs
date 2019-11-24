using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Monom
    {
        public double Coefficient { get; set; }

        public double Power { get; set; }

        public Monom(double coefficient, double power)
        {
            Coefficient = coefficient;
            Power = power;
        }

        public Monom()
        {

        }

        public static Monom operator *(Monom first, Monom second)
        {
            return new Monom(first.Coefficient * second.Coefficient, first.Power + second.Power);
        }

        public static Monom operator /(Monom first, Monom second)
        {
            return new Monom(first.Coefficient / second.Coefficient, first.Power - second.Power);
        }

        public static Monom operator *(Monom monom, double number)
        {
            return new Monom(monom.Coefficient * number, monom.Power);
        }

        public static Monom operator /(Monom monom, double number)
        {
            return new Monom(monom.Coefficient / number, monom.Power);
        }
    }
}
