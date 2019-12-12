using System;

namespace AbstractClassesLibrary
{
    public abstract class AbstractRectangle : AbstractFigure
    {
        public double FirstSide { get; set; }

        public double SecondSide { get; set; }

        public AbstractRectangle()
        {

        }

        public AbstractRectangle(double firstSide, double secondSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
        }

        public override double GetPerimeter()
        {
            return Math.Round(((FirstSide + SecondSide) * 2), 4);
        }

        public override double GetSquare()
        {
            return Math.Round(FirstSide * SecondSide, 4);
        }
    }
}
