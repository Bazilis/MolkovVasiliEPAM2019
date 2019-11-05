using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Task01_NET
{
    public class GCD
    {
        public int EuclideanGCD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        public int EuclideanGCD(int a, int b, int c)
        {
            return EuclideanGCD(EuclideanGCD(a, b), c);
        }

        public int EuclideanGCD(int a, int b, int c, int d)
        {
            return EuclideanGCD(EuclideanGCD(a, b, c), d);
        }

        public int EuclideanGCD(int a, int b, int c, int d, int e)
        {
            return EuclideanGCD(EuclideanGCD(a, b, c, d), e);
        }

        
    }
}
