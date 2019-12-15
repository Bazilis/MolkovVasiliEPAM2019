using System;
using ClassLibrary.AbstractClasses;

namespace ClassLibrary.FilmFigureClasses
{
    public class FilmEquilateralTriangle : AbstractEquilateralTriangle
    {
        /// <summary>
        /// Class for film equilateral triangle, inherited from AbstractEquilateralTriangle class
        /// </summary>
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
