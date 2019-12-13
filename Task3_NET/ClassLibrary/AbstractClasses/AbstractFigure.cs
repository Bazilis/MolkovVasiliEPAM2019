using System;

namespace ClassLibrary.AbstractClasses
{
    public abstract class AbstractFigure
    {
        public abstract double GetPerimeter();

        public abstract double GetArea();

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return (obj is AbstractFigure) && (this.GetType() == obj.GetType())
                                           && (this.GetArea() == (obj as AbstractFigure).GetArea());
        }

        public override int GetHashCode()
        {
            return GetPerimeter().GetHashCode();
        }

        public override string ToString()
        {
            return ($"'{this.GetType().Name}'");
        }
    }
}