using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    /// <summary>
    /// Base class for creating isosceles triangle, inherited from AbstractFigure class
    /// </summary>
    public abstract class AbstractIsoscelesTriangle : AbstractFigure
    {
        private double firstAndSecondSides;

        private double thirdSide;

        /// <summary>
        /// First and second sides of isosceles triangle (they are equal)
        /// </summary>
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

        /// <summary>
        /// Third side of isosceles triangle (base of triangle)
        /// </summary>
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

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AbstractIsoscelesTriangle()
        {
            throw new CreationException($"Sides of {this.ToString()} equals zero");
        }

        /// <summary>
        /// Constructor with parameters and checking isosceles triangle for existanse
        /// </summary>
        /// <param name="firstAndSecondSides"></param>
        /// <param name="thirdSide"></param>
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

        /// <summary>
        /// Constructor with parameters for creating isosceles triangle from other figure
        /// </summary>
        /// <param name="firstAndSecondSides"></param>
        /// <param name="thirdSide"></param>
        /// <param name="figure"></param>
        public AbstractIsoscelesTriangle(double firstAndSecondSides, double thirdSide, AbstractFigure figure) : this(firstAndSecondSides, thirdSide)
        {
            CreationException.FiguresHandler(this, figure);
        }

        /// <summary>
        /// Override GetPerimeter() method for calculating isosceles triangle perimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return Math.Round(firstAndSecondSides + thirdSide, 4);
        }

        /// <summary>
        /// Override GetArea() method for calculating isosceles triangle area
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return Math.Round((Math.Sqrt(Math.Pow(2 * firstAndSecondSides, 2) - Math.Pow(thirdSide, 2)) * (thirdSide / 4)), 4);
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"'{this.GetType().Name}', sides '{firstAndSecondSides}', '{firstAndSecondSides}' and '{thirdSide}'";
        }
    }
}
