using System;

namespace ClassLibrary.ExceptionClasses
{
    public class ParserException : Exception
    {
        public ParserException(string message) : base(message)
        {

        }

        public ParserException() : this("Parser exception")
        {

        }
    }
}
