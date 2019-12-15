using System;
using ClassLibrary.PaperFigureClasses;

namespace ClassLibrary.AbstractClasses
{
    /// <summary>
    /// Base class for any figure
    /// </summary>
    public abstract class AbstractFigure
    {
        /// <summary>
        /// Abstract method for obtaining the perimeter of any figure
        /// </summary>
        /// <returns></returns>
        public abstract double GetPerimeter();

        /// <summary>
        /// Abstract method for obtaining the area of any figure
        /// </summary>
        /// <returns></returns>
        public abstract double GetArea();

        /// <summary>
        /// Abstract method for comparing figures
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return (obj is AbstractFigure) && (this.GetType() == obj.GetType())
                                           && (this.GetArea() == (obj as AbstractFigure).GetArea())
                                           && ((this as IPainted).FigureColor == (obj as IPainted).FigureColor);
        }

        /// <summary>
        /// Override GetHashCode() method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetPerimeter().GetHashCode();
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"'{this.GetType().Name}'");
        }
    }
}
