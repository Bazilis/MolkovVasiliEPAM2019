using System;
using ClassLibrary.AbstractClasses;

namespace ClassLibrary.FilmFigureClasses
{
    public class FilmIsoscelesTriangle : AbstractIsoscelesTriangle
    {
        public FilmIsoscelesTriangle()
        {

        }

        public FilmIsoscelesTriangle(double firstAndSecondSides, double thirdSide) : base(firstAndSecondSides, thirdSide)
        {

        }

        public FilmIsoscelesTriangle(double firstAndSecondSides, double thirdSide, AbstractFigure figure) : base(firstAndSecondSides, thirdSide, figure)
        {

        }
    }
}