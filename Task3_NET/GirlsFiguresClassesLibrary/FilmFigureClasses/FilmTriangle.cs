using System;
using ClassLibrary.AbstractClasses;

namespace ClassLibrary.FilmFigureClasses
{
    /// <summary>
    /// Class for film triangle, inherited from AbstractTriangle class
    /// </summary>
    public class FilmTriangle : AbstractTriangle
    {
        public FilmTriangle()
        {

        }

        public FilmTriangle(double firstSide, double secondSide, double thirdSide) : base(firstSide, secondSide, thirdSide)
        {

        }

        public FilmTriangle(double firstSide, double secondSide, double thirdSide, AbstractFigure figure) : base(firstSide, secondSide, thirdSide, figure)
        {

        }
    }
}
