using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
