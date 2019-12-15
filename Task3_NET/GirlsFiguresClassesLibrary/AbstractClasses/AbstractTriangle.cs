using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    public abstract class AbstractTriangle : AbstractFigure
    {
        private double firstSide;

        private double secondSide;

        private double thirdSide;

        public double FirstSide
        {
            get
            {
                return firstSide;
            }

            set
            {
                if (value <= 0)
                    throw new CreationException($"FirstSide '{value}' of '{this.GetType().Name}' less than or equal to zero");

                firstSide = value;
            }
        }

        public double SecondSide
        {
            get
            {
                return secondSide;
            }

            set
            {
                if (value <= 0)
                    throw new CreationException($"SecondSide {value} of '{this.GetType().Name}' less than or equal to zero");

                secondSide = value;
            }
        }

        public double ThirdSide
        {
            get
            {
                return thirdSide;
            }

            set
            {
                if (value <= 0)
                    throw new CreationException($"ThirdSide {value} of '{this.GetType().Name}' less than or equal to zero");

                thirdSide = value;
            }
        }

        public AbstractTriangle()
        {
            throw new CreationException($"Sides of {this.ToString()} equals zero");
        }

        public AbstractTriangle(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide + secondSide > thirdSide)
            {
                if (firstSide + thirdSide > secondSide)
                {
                    if (secondSide + thirdSide > firstSide)
                    {
                        FirstSide = firstSide;
                        SecondSide = secondSide;
                        ThirdSide = thirdSide;
                    }
                    else
                    {
                        throw new CreationException($"{this.ToString()} with such sides does not exist. First side is longer or equal to the sum of the other two");
                    }
                }
                else
                {
                    throw new CreationException($"{this.ToString()} with such sides does not exist. Second side is longer or equal to the sum of the other two");
                }
            }
            else
            {
                throw new CreationException($"{this.ToString()} with such sides does not exist. Third side is longer or equal to the sum of the other two");
            }
        }

        public AbstractTriangle(double firstSide, double secondSide, double thirdSide, AbstractFigure figure) : this(firstSide, secondSide, thirdSide)
        {
            CreationException.FiguresHandler(this, figure);
        }

        public override double GetPerimeter()
        {
            return firstSide + secondSide + thirdSide;
        }

        public override double GetArea()
        {
            double semiPerimeter = (this.GetPerimeter() / 2);   // half of perimeter

            return Math.Round(Math.Sqrt(semiPerimeter *
                                       (semiPerimeter - firstSide) *
                                       (semiPerimeter - secondSide) *
                                       (semiPerimeter - thirdSide)), 4);
        }

        public override string ToString()
        {
            return $"'{this.GetType().Name}', sides '{firstSide}', '{secondSide}' and '{thirdSide}'";
        }
    }
}
