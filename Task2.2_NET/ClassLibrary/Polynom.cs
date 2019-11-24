using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Polynom
    {
        /// <summary>
        /// Automatic property for list of Monom types
        /// </summary>
        public List<Monom> Monoms { get; set; }

        /// <summary>
        /// Constructor with parameter for Polynom type
        /// </summary>
        /// <param name="monoms">List of Monom types</param>
        public Polynom(List<Monom> monoms)
        {
            Monoms = monoms;
        }

        /// <summary>
        /// Default constructor for Polynom type
        /// </summary>
        public Polynom() : this(new List<Monom>())
        {

        }

        /// <summary>
        /// Overloaded operator '+' for for Polynom and Monom types addition
        /// </summary>
        /// <param name="polynom">Polynom type parameter</param>
        /// <param name="monom">Monom type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator +(Polynom polynom, Monom monom)
        {
            Polynom resultPolynom = new Polynom();

            foreach (Monom item in polynom.Monoms)
            {
                resultPolynom.Monoms.Add(item);
            }

            foreach (Monom item in resultPolynom.Monoms)
            {
                if (item.Power == monom.Power)
                {
                    if ((item.Coefficient + monom.Coefficient) == 0)
                    {
                        resultPolynom.Monoms.Remove(item);
                        return resultPolynom;
                    }

                    item.Coefficient += monom.Coefficient;

                    return resultPolynom;
                }
            }

            resultPolynom.Monoms.Add(monom);

            return resultPolynom;
        }

        /// <summary>
        /// Overloaded operator '-' for for Polynom and Monom types subtruction
        /// </summary>
        /// <param name="polynom">Polynom type parameter</param>
        /// <param name="monom">Monom type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator -(Polynom polynom, Monom monom)
        {
            return polynom + monom * (-1);
        }

        /// <summary>
        /// Overloaded operator '+' for for Polynom types addition
        /// </summary>
        /// <param name="first">First Polynom type parameter</param>
        /// <param name="second">Second Polynom type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator +(Polynom first, Polynom second)
        {
            Polynom resultPolynom = new Polynom();

            foreach (Monom value in first.Monoms)
            {
                resultPolynom += value;
            }

            foreach (Monom value in second.Monoms)
            {
                resultPolynom += value;
            }

            return resultPolynom;
        }

        /// <summary>
        /// Overloaded operator '-' for for Polynom types subtruction
        /// </summary>
        /// <param name="first">First Polynom type parameter</param>
        /// <param name="second">Second Polynom type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator -(Polynom first, Polynom second)
        {
            return first + second * (-1);
        }

        /// <summary>
        /// Overloaded operator '*' for Polynom type and double type multiplication
        /// </summary>
        /// <param name="polynom">Polynom type parameter</param>
        /// <param name="number">Double type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator *(Polynom polynom, double number)
        {
            Polynom resultPolynom = new Polynom();

            foreach (Monom item in polynom.Monoms)
            {
                resultPolynom += item * number;
            }

            return resultPolynom;
        }

        /// <summary>
        /// Overloaded operator '/' for Polynom type and double type division
        /// </summary>
        /// <param name="polynom">Polynom type parameter</param>
        /// <param name="number">Double type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator /(Polynom polynom, double number)
        {
            Polynom resultPolynom = new Polynom();
            foreach (Monom item in polynom.Monoms)
            {
                resultPolynom += item / number;
            }

            return resultPolynom;
        }

        /// <summary>
        /// Overloaded operator '*' for for Polynom and Monom types multiplication
        /// </summary>
        /// <param name="polynom">Polynom type parameter</param>
        /// <param name="monom">Monom type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator *(Polynom polynom, Monom monom)
        {
            Polynom resultPolynom = new Polynom();

            foreach (Monom value in polynom.Monoms)
            {
                resultPolynom += value * monom;
            }

            return resultPolynom;
        }

        /// <summary>
        /// Overloaded operator '*' for for Polynom types multiplication
        /// </summary>
        /// <param name="first">First Polynom type parameter</param>
        /// <param name="second">Second Polynom type parameter</param>
        /// <returns>New Polynom type</returns>
        public static Polynom operator *(Polynom first, Polynom second)
        {
            Polynom temporaryPolynom = new Polynom();
            foreach (Monom item in first.Monoms)
            {
                temporaryPolynom += second * item;
            }

            Polynom resultPolynom = new Polynom();
            foreach (Monom item in temporaryPolynom.Monoms)
            {
                resultPolynom += item;
            }

            return resultPolynom;
        }

        /// <summary>
        /// Overload comparison operator '=='
        /// </summary>
        /// <param name="first">First Polynom type parameter</param>
        /// <param name="second">Second Polynom type parameter</param>
        /// <returns>Bool type</returns>
        public static bool operator ==(Polynom first, Polynom second)
        {
            if (first.Monoms.Count == second.Monoms.Count)
            {
                int countEquals = 0;
                foreach (Monom firstItem in first.Monoms)
                {
                    foreach (Monom secondItem in second.Monoms)
                    {
                        if (firstItem == secondItem)
                        {
                            countEquals++;
                        }
                    }
                }
                if (countEquals == first.Monoms.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Overload comparison operator '!='
        /// </summary>
        /// <param name="first">First Polynom type parameter</param>
        /// <param name="second">Second Polynom type parameter</param>
        /// <returns>Bool type</returns>
        public static bool operator !=(Polynom first, Polynom second)
        {
            if (first.Monoms.Count == second.Monoms.Count)
            {
                int countEquals = 0;
                foreach (Monom firstItem in first.Monoms)
                {
                    foreach (Monom secondItem in second.Monoms)
                    {
                        if (firstItem == secondItem)
                        {
                            countEquals++;
                        }
                    }
                }
                if (countEquals == first.Monoms.Count)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Convertation Polynom type to String type
        /// </summary>
        /// <returns>String type</returns>
        private string PolynomToString()
        {
            string polynomToString = "";

            foreach (Monom item in Monoms)
            {
                if (polynomToString == "" || item.Coefficient < 0)
                {
                    polynomToString = string.Concat(polynomToString, item.ToString());
                }
                else
                {
                    polynomToString = string.Concat(polynomToString, $"+{item.ToString()}");
                }

            }

            return polynomToString;
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

            Polynom polynom = (Polynom)obj;

            if (Monoms.Count == polynom.Monoms.Count)
            {
                int countEquals = 0;
                foreach (Monom item in polynom.Monoms)
                {
                    foreach (Monom thisItem in Monoms)
                    {
                        if (item.Equals(thisItem))
                        {
                            countEquals++;
                        }
                    }
                }
                if (countEquals == polynom.Monoms.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            double sum = 0;
            foreach (Monom item in Monoms)
            {
                sum += item.Coefficient + item.Power;
            }

            return sum.GetHashCode();
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns>String type</returns>
        public override string ToString()
        {
            return PolynomToString().ToString();
        }
    }
}
