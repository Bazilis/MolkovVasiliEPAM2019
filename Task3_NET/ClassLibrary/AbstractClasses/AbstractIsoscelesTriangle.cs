using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    public abstract class AbstractIsoscelesTriangle : AbstractFigure
    {
        private double firstAndSecondSides;

        private double thirdSide;

        public double FirstAndSecondSides
        {
            get
            {
                return firstAndSecondSides;
            }

            set
            {
                if (value <= 0)
                    throw new CreationException($"First and Second side '{value}' of '{this.GetType().Name}' less than or equal to zero");

                firstAndSecondSides = value;
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

        public AbstractIsoscelesTriangle()
        {
            throw new CreationException($"Sides of {this.ToString()} equals zero");
        }

        public AbstractIsoscelesTriangle(double firstAndSecondSides, double thirdSide)
        {
            if ((2 * firstAndSecondSides) > thirdSide)
            {
                FirstAndSecondSides = firstAndSecondSides;
                ThirdSide = thirdSide;
            }
            else
            {
                throw new CreationException($"{this.ToString()} with such sides does not exist. Sum of the First and Second sides must be greater than the Third side");
            }
        }

        public AbstractIsoscelesTriangle(double firstAndSecondSides, double thirdSide, AbstractFigure figure) : this(firstAndSecondSides, thirdSide)
        {
            CreationException.FiguresHandler(this, figure);
        }

        public override double GetPerimeter()
        {
            return Math.Round(firstAndSecondSides + thirdSide, 4);
        }

        public override double GetArea()
        {
            return Math.Round((Math.Sqrt(Math.Pow(2 * firstAndSecondSides, 2) - Math.Pow(thirdSide, 2)) * (thirdSide / 4)), 4);
        }

        public override string ToString()
        {
            return $"'{this.GetType().Name}', sides '{firstAndSecondSides}', '{firstAndSecondSides}' and '{thirdSide}'";
        }
    }
}