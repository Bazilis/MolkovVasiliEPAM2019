using System;
using ClassLibrary.AbstractClasses;

namespace ClassLibrary.ExceptionClasses
{
    public class CreationException : Exception
    {
        public CreationException(string message) : base(message)
        {

        }

        public CreationException() : this("Creation exception")
        {

        }

        public static void FiguresHandler(AbstractFigure first, AbstractFigure second)
        {
            if (second.GetArea() <= first.GetArea())
                throw new CreationException($"Square of figure '{second.ToString()}' not enough to create figure '{first.ToString()}'");
        }
    }
}
