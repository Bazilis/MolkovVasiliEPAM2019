using System;

namespace ClassLibrary.ExceptionClasses
{
    public class GirlsBoxWithFiguresException : Exception
    {
        public GirlsBoxWithFiguresException(string message) : base(message)
        {

        }

        public GirlsBoxWithFiguresException() : this("Box with figures exception")
        {

        }
    }
}
