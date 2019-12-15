using System;

namespace ClassLibrary.ExceptionClasses
{
    public class PaintException : Exception
    {
        public PaintException(string message) : base(message)
        {

        }

        public PaintException() : this("Paint exception")
        {

        }
    }
}
