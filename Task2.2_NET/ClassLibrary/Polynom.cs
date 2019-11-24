using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Polynom
    {
        public List<Monom> Monoms { get; set; }

        public Polynom(List<Monom> monoms)
        {
            Monoms = monoms;
        }

        public Polynom() : this(new List<Monom>())
        {

        }

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

        public static Polynom operator -(Polynom polynom, Monom monom)
        {
            return polynom + monom * (-1);
        }

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

        public static Polynom operator -(Polynom first, Polynom second)
        {
            return first + second * (-1);
        }

        public static Polynom operator *(Polynom polynom, double number)
        {
            Polynom resultPolynom = new Polynom();

            foreach (Monom item in polynom.Monoms)
            {
                resultPolynom += item * number;
            }

            return resultPolynom;
        }

        public static Polynom operator *(Polynom polynom, Monom monom)
        {
            Polynom resultPolynom = new Polynom();

            foreach (Monom value in polynom.Monoms)
            {
                resultPolynom += value * monom;
            }

            return resultPolynom;
        }

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
    }
}
