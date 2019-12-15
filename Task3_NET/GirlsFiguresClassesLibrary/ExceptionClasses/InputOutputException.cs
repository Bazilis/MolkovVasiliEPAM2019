using System;

namespace ClassLibrary.ExceptionClasses
{
    public class InputOutputException : Exception
    {
        public InputOutputException(string message) : base(message)
        {

        }

        public InputOutputException() : this("Input/output exception")
        {

        }
    }
}