using System;
using ClassLibrary.AbstractClasses;

namespace ClassLibrary.FilmFigureClasses
{
    /// <summary>
    /// Class for film circle, inherited from AbstractCircle class
    /// </summary>
    public class FilmCircle : AbstractCircle
    {
        public FilmCircle()
        {

        }

        public FilmCircle(double radius) : base(radius)
        {

        }

        public FilmCircle(double radius, AbstractFigure figure) : base(radius, figure)
        {

        }
    }
}
