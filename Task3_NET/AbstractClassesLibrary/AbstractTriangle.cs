using System;

namespace AbstractClassesLibrary
{
    public abstract class AbstractTriangle : AbstractFigure
    {
        public double FirstSide { get; set; }

        public double SecondSide { get; set; }

        public double ThirdSide { get; set; }

        public AbstractTriangle()
        {

        }

        public AbstractTriangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        public override double GetPerimeter()
        {
            return FirstSide + SecondSide + ThirdSide;
        }

        public override double GetSquare()
        {
            double semiPerimeter = (this.GetPerimeter() / 2);   // half of perimeter

            return Math.Round(Math.Sqrt(semiPerimeter *
                                       (semiPerimeter - FirstSide) *
                                       (semiPerimeter - SecondSide) *
                                       (semiPerimeter - ThirdSide)), 4);
        }
    }
}
