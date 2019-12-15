using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    /// <summary>
    /// Base class for creating rectangle, inherited from AbstractFigure class
    /// </summary>
    public abstract class AbstractRectangle : AbstractFigure
    {
        private double firstSide;

        private double secondSide;

        /// <summary>
        /// First side of rectangle
        /// </summary>
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

        /// <summary>
        /// Second side of rectangle
        /// </summary>
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

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AbstractRectangle()
        {
            throw new CreationException($"Sides of {this.ToString()} equals zero");
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        public AbstractRectangle(double firstSide, double secondSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
        }

        /// <summary>
        /// Constructor with parameters for creating rectangle from other figure
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="figure"></param>
        public AbstractRectangle(double firstSide, double secondSide, AbstractFigure figure) : this(firstSide, secondSide)
        {
            CreationException.FiguresHandler(this, figure);
        }

        /// <summary>
        /// Override GetPerimeter() method for calculating rectangle perimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return Math.Round(((firstSide + secondSide) * 2), 4);
        }

        /// <summary>
        /// Override GetArea() method for calculating rectangle area
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return Math.Round(firstSide * secondSide, 4);
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"'{this.GetType().Name}', sides '{firstSide}' and '{secondSide}'";
        }
    }
}
