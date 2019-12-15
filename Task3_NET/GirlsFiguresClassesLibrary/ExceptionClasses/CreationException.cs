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

        /// <summary>
        /// Method, that checks, when creating one figure from another whether the colors of the figures match
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public static void ColorsHandler(Colors first, Colors second)
        {
            if (first != second)
                throw new CreationException($"Impossible to create a '{second.ToString()}' figure from a '{first.ToString()}' figure");
        }

        /// <summary>
        /// Method, that checks, when creating one figure from another whether the figures material add area matches
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public static void FiguresHandler(AbstractFigure first, AbstractFigure second)
        {
            if ((first is IPainted) != (second is IPainted))
                throw new CreationException($"Material of figure '{second.ToString()}' not suitable to create figure '{first.ToString()}'");

            if (second.GetArea() <= first.GetArea())
                throw new CreationException($"Area of figure '{second.ToString()}' not enough to create figure '{first.ToString()}'");
        }
    }
}
