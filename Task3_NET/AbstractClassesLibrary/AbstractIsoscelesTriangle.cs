using System;

namespace AbstractClassesLibrary
{
    public abstract class AbstractIsoscelesTriangle : AbstractFigure
    {
        public double FirstAndSecondSides { get; set; }

        public double ThirdSide { get; set; }

        public AbstractIsoscelesTriangle()
        {

        }

        public AbstractIsoscelesTriangle(double firstAndSecondSides, double thirdSide)
        {
            FirstAndSecondSides = firstAndSecondSides;
            ThirdSide = thirdSide;
        }

        public override double GetPerimeter()
        {
            return Math.Round(FirstAndSecondSides + ThirdSide, 4);
        }

        public override double GetSquare()
        {
            return Math.Round((Math.Sqrt(Math.Pow(2 * FirstAndSecondSides, 2) - Math.Pow(ThirdSide, 2)) * (ThirdSide / 4)), 4);
        }
    }
}
