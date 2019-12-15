using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    /// <summary>
    /// Base class for creating circles, inherited from AbstractFigure class
    /// </summary>
    public abstract class AbstractCircle : AbstractFigure
    {
        private double radius;

        /// <summary>
        /// Radius of circle
        /// </summary>
        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value <= 0)
                    throw new CreationException($"Radius of '{this.GetType().Name}', radius '{value}' less than or equal to zero");

                radius = value;
            }
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AbstractCircle()
        {
            throw new CreationException($"Radius of {this.ToString()} equals zero");
        }

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        /// <param name="radius"></param>
        public AbstractCircle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Constructor with parameters for creating circle from other figure
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="figure"></param>
        public AbstractCircle(double radius, AbstractFigure figure) : this(radius)
        {
            CreationException.FiguresHandler(this, figure);
        }

        /// <summary>
        /// Override GetPerimeter() method for calculating circle perimeter
        /// </summary>
        /// <returns></returns>
        public sealed override double GetPerimeter()
        {
            return Math.Round(2 * Math.PI * Radius, 4);
        }

        /// <summary>
        /// Override GetArea() method for calculating circle area
        /// </summary>
        /// <returns></returns>
        public sealed override double GetArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 4);
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"'{this.GetType().Name}', radius '{this.radius}'";
        }
    }
}
