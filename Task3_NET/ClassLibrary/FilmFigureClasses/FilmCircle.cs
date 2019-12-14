using System;
using ClassLibrary.AbstractClasses;

namespace ClassLibrary.FilmFigureClasses
{
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