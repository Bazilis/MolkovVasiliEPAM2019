using System;

namespace AbstractClassesLibrary
{
    public abstract class AbstractEquilateralTriangle : AbstractFigure
    {
        public double Side { get; set; }

        public AbstractEquilateralTriangle()
        {

        }

        public AbstractEquilateralTriangle(double side)
        {
            Side = side;
        }

        public override double GetPerimeter()
        {
            return Math.Round(3 * Side, 4);
        }

        public override double GetSquare()
        {
            return Math.Round(Math.Sqrt(0.1875) * Side * Side, 4);
        }
    }
}
