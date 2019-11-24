using System;
using System.Collections.Generic;

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

        public static Polynom operator +(Monom first, Monom second)
        {
            if (first.Power == second.Power)
            {
                if ((first.Coefficient + second.Coefficient) == 0)
                {
                    return new Polynom();
                }

                return new Polynom
                {
                    Monoms = new List<Monom>() { new Monom(first.Coefficient + second.Coefficient, first.Power) }
                };
            }
            else
            {
                return new Polynom
                {
                    Monoms = new List<Monom>() { first, second }
                };
            }
        }

        public static Polynom operator -(Monom first, Monom second)
        {
            return first + second * (-1);
        }

        public static bool operator ==(Monom first, Monom second)
        {
            return (first.Power == second.Power && first.Coefficient == second.Coefficient);
        }

        public static bool operator !=(Monom first, Monom second)
        {
            return (first.Power != second.Power || first.Coefficient != second.Coefficient);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Monom monom = (Monom)obj;

            if (Power == monom.Power && Coefficient == monom.Coefficient)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (Coefficient + Power).GetHashCode();
        }

        public override string ToString()
        {
            return ($"{Coefficient}x^{Power}");
        }
    }
}
