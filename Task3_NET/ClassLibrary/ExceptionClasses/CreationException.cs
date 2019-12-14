using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.PaperFigureClasses;

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

        public static void ColorsHandler(Colors first, Colors second)
        {
            if (first != second)
                throw new CreationException($"Impossible to create a '{second.ToString()}' figure from a '{first.ToString()}' figure");
        }

        public static void FiguresHandler(AbstractFigure first, AbstractFigure second)
        {
            if ((first is IPainted) != (second is IPainted))
                throw new CreationException($"Material of figure '{second.ToString()}' not suitable to create figure '{first.ToString()}'");

            if (second.GetArea() <= first.GetArea())
                throw new CreationException($"Square of figure '{second.ToString()}' not enough to create figure '{first.ToString()}'");
        }
    }
}
