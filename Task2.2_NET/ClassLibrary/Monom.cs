using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Class for describing operations with monoms
    /// </summary>
    public class Monom
    {
        /// <summary>
        /// Automatic property for coefficient of variable
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// Automatic property for power of variable
        /// </summary>
        public double Power { get; set; }

        /// <summary>
        /// Constructor with parameters for Monom type
        /// </summary>
        /// <param name="coefficient">Coefficient of variable</param>
        /// <param name="power">Power of variable</param>
        public Monom(double coefficient, double power)
        {
            Coefficient = coefficient;
            Power = power;
        }

        /// <summary>
        /// Default constructor for Monom type
        /// </summary>
        public Monom()
        {

        }

        /// <summary>
        /// Overloaded operator '*' for for Monom types multiplication
        /// </summary>
        /// <param name="first">First Monom type parameter</param>
        /// <param name="second">Second Monom type parameter</param>
        /// <returns>New Monom type</returns>
        public static Monom operator *(Monom first, Monom second)
        {
            return new Monom(first.Coefficient * second.Coefficient, first.Power + second.Power);
        }

        /// <summary>
        /// Overloaded operator '/' for for Monom types division
        /// </summary>
        /// <param name="first">First Monom type parameter</param>
        /// <param name="second">Second Monom type parameter</param>
        /// <returns>New Monom type</returns>
        public static Monom operator /(Monom first, Monom second)
        {
            return new Monom(first.Coefficient / second.Coefficient, first.Power - second.Power);
        }

        /// <summary>
        /// Overloaded operator '*' for Monom type and double type multiplication
        /// </summary>
        /// <param name="monom">First Monom type parameter</param>
        /// <param name="number">Second Monom type parameter</param>
        /// <returns>New Monom type</returns>
        public static Monom operator *(Monom monom, double number)
        {
            return new Monom(monom.Coefficient * number, monom.Power);
        }

        /// <summary>
        /// Overloaded operator '/' for Monom type and double type division
        /// </summary>
        /// <param name="monom">First Monom type parameter</param>
        /// <param name="number">Second Monom type parameter</param>
        /// <returns>New Monom type</returns>
        public static Monom operator /(Monom monom, double number)
        {
            return new Monom(monom.Coefficient / number, monom.Power);
        }

        /// <summary>
        /// Overloaded operator '+' for for Monom types addition
        /// </summary>
        /// <param name="first">First Monom type parameter</param>
        /// <param name="second">Second Monom type parameter</param>
        /// <returns>New Polynom type</returns>
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

        /// <summary>
        /// Overloaded operator '-' for for Monom types subtruction
        /// </summary>
        /// <param name="first">First Monom type parameter</param>
        /// <param name="second">Second Monom type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator -(Monom first, Monom second)
        {
            return first + second * (-1);
        }

        /// <summary>
        /// Overload comparison operator '=='
        /// </summary>
        /// <param name="first">First Monom type parameter</param>
        /// <param name="second">Second Monom type parameter</param>
        /// <returns>Bool type</returns>
        public static bool operator ==(Monom first, Monom second)
        {
            return (first.Power == second.Power && first.Coefficient == second.Coefficient);
        }

        /// <summary>
        /// Overload comparison operator '!='
        /// </summary>
        /// <param name="first">First Monom type parameter</param>
        /// <param name="second">Second Monom type parameter</param>
        /// <returns>Bool type</returns>
        public static bool operator !=(Monom first, Monom second)
        {
            return (first.Power != second.Power || first.Coefficient != second.Coefficient);
        }

        /// <summary>
        /// Override Equals() method
        /// </summary>
        /// <param name="obj">Object type</param>
        /// <returns>Bool type</returns>
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

        /// <summary>
        /// Override GetHashCode() method
        /// </summary>
        /// <returns>Integer type</returns>
        public override int GetHashCode()
        {
            return (Coefficient + Power).GetHashCode();
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns>String type</returns>
        public override string ToString()
        {
            return ($"{Coefficient}x^{Power}");
        }
    }
}
