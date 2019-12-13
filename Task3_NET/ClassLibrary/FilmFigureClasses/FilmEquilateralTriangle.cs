using System;
using ClassLibrary.AbstractClasses;

namespace ClassLibrary.FilmFigureClasses
{
    public class FilmEquilateralTriangle : AbstractEquilateralTriangle
    {
        public FilmEquilateralTriangle()
        {

        }

        public FilmEquilateralTriangle(double side) : base(side)
        {

        }

        public FilmEquilateralTriangle(double side, AbstractFigure figure) : base(side, figure)
        {

        }
    }
}
