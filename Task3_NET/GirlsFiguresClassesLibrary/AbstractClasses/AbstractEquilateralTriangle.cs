using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    /// <summary>
    /// Base class for creating equilateral triangleы, inherited from AbstractFigure class
    /// </summary>
    public abstract class AbstractEquilateralTriangle : AbstractFigure
    {
        private double side;

        /// <summary>
        /// Side of equilateral triangle (all sides of equilateral triangle are equal)
        /// </summary>
        public double Side
        {
            get
            {
                return side;
            }

            set
            {
                if (value <= 0)
                    throw new CreationException($"Side '{value}' of '{this.GetType().Name}' less than or equal to zero");

                side = value;
            }
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AbstractEquilateralTriangle()
        {
            throw new CreationException($"Sides of {this.ToString()} equals zero");
        }

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        /// <param name="side"></param>
        public AbstractEquilateralTriangle(double side)
        {
            Side = side;
        }

        /// <summary>
        /// Constructor with parameters for creating equilateral triangle from other figure
        /// </summary>
        /// <param name="side"></param>
        /// <param name="figure"></param>
        public AbstractEquilateralTriangle(double side, AbstractFigure figure) : this(side)
        {
            CreationException.FiguresHandler(this, figure);
        }

        /// <summary>
        /// Override GetPerimeter() method for calculating equilateral triangle perimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return Math.Round(3 * side, 4);
        }

        /// <summary>
        /// Override GetArea() method for calculating equilateral triangle area
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return Math.Round((Math.Sqrt(0.1875) * side * side), 4);
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"'{this.GetType().Name}', sides '{side}', '{side}' and '{side}'";
        }
    }
}
