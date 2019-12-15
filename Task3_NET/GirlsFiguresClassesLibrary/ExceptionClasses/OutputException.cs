using System;

namespace ClassLibrary.ExceptionClasses
{
    public class OutputException : Exception
    {
        public OutputException(string message) : base(message)
        {

        }

        public OutputException() : this("Output exception")
        {

        }
    }
}