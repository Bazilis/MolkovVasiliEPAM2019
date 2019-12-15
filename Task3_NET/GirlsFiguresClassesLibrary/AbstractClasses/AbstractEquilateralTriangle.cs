using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    public abstract class AbstractEquilateralTriangle : AbstractFigure
    {
        private double side;

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

        public AbstractEquilateralTriangle()
        {
            throw new CreationException($"Sides of {this.ToString()} equals zero");
        }

        public AbstractEquilateralTriangle(double side)
        {
            Side = side;
        }

        public AbstractEquilateralTriangle(double side, AbstractFigure figure) : this(side)
        {
            CreationException.FiguresHandler(this, figure);
        }

        public override double GetPerimeter()
        {
            return Math.Round(3 * side, 4);
        }

        public override double GetArea()
        {
            return Math.Round((Math.Sqrt(0.1875) * side * side), 4);
        }

        public override string ToString()
        {
            return $"'{this.GetType().Name}', sides '{side}', '{side}' and '{side}'";
        }
    }
}
