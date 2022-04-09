using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions
{
    public class BookException : Exception
    {
        public BookException(string message) : base(message) { }
    }
}
