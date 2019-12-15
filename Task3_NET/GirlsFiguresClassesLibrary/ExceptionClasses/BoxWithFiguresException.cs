using System;

namespace ClassLibrary.ExceptionClasses
{
    public class BoxWithFiguresException : Exception
    {
        public BoxWithFiguresException(string message) : base(message)
        {

        }

        public BoxWithFiguresException() : this("Box with figures exception")
        {

        }
    }
}
