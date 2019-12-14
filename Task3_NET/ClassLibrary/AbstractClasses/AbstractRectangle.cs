using System;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.AbstractClasses
{
    public abstract class AbstractRectangle : AbstractFigure
    {
        private double firstSide;

        private double secondSide;

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

        public AbstractRectangle()
        {
            throw new CreationException($"Sides of {this.ToString()} equals zero");
        }

        public AbstractRectangle(double firstSide, double secondSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
        }

        public AbstractRectangle(double firstSide, double secondSide, AbstractFigure figure) : this(firstSide, secondSide)
        {
            CreationException.FiguresHandler(this, figure);
        }

        public override double GetPerimeter()
        {
            return Math.Round(((firstSide + secondSide) * 2), 4);
        }

        public override double GetArea()
        {
            return Math.Round(firstSide * secondSide, 4);
        }

        public override string ToString()
        {
            return $"'{this.GetType().Name}', sides '{firstSide}' and '{secondSide}'";
        }
    }
}
