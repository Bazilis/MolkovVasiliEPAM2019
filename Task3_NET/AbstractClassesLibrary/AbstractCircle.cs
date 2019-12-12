using System;

namespace AbstractClassesLibrary
{
    public abstract class AbstractCircle : AbstractFigure
    {
        public double Radius { get; set; }

        public AbstractCircle()
        {

        }

        public AbstractCircle(double radius)
        {
            Radius = radius;
        }

        public sealed override double GetPerimeter()
        {
            return Math.Round(2 * Math.PI * Radius, 4);
        }

        public sealed override double GetSquare()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 4);
        }
    }
}
