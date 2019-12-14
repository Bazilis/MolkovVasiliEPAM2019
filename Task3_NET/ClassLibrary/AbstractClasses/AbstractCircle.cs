using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    public abstract class AbstractCircle : AbstractFigure
    {
        private double radius;

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

        public AbstractCircle()
        {
            throw new CreationException($"Radius of {this.ToString()} equals zero");
        }

        public AbstractCircle(double radius)
        {
            Radius = radius;
        }

        public AbstractCircle(double radius, AbstractFigure figure) : this(radius)
        {
            CreationException.FiguresHandler(this, figure);
        }

        public sealed override double GetPerimeter()
        {
            return Math.Round(2 * Math.PI * Radius, 4);
        }

        public sealed override double GetArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 4);
        }

        public override string ToString()
        {
            return $"'{this.GetType().Name}', radius '{this.radius}'";
        }
    }
}