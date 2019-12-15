using System;
using ClassLibrary.AbstractClasses;

namespace ClassLibrary.FilmFigureClasses
{
    /// <summary>
    /// Class for film rectangle, inherited from AbstractRectangle class
    /// </summary>
    public class FilmRectangle : AbstractRectangle
    {
        public FilmRectangle()
        {

        }

        public FilmRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {

        }

        public FilmRectangle(double firstSide, double secondSide, AbstractFigure figure) : base(firstSide, secondSide, figure)
        {

        }
    }
}
