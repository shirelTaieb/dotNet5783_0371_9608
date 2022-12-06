using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class doseNotExistException : Exception
    {
        public doseNotExistException() : base() { }
        public doseNotExistException(string message) : base(message) { }
        public doseNotExistException(string message, Exception inner) : base(message, inner) { }

        override public string Message => " this item dosen't exist";
        override public string ToString() => Message;
    }
    public class wrongDataException : Exception
    {
        public wrongDataException() : base() { }
        public wrongDataException(string message) : base(message) { }
        public wrongDataException(string message, Exception inner) : base(message, inner) { }

        override public string Message => "The Data is invalide";
        override public string ToString() => Message;
    }
    public class alreadyExistException : Exception
    {
        public alreadyExistException() : base() { }
        public alreadyExistException(string message) : base(message) { }
        public alreadyExistException(string message, Exception inner) : base(message, inner) { }

        override public string Message => "The Data already Exist";
        override public string ToString() => Message;
    }

    public class notInStockException : Exception
    {
        public notInStockException() : base() { }
        public notInStockException(string message) : base(message) { }
        public notInStockException(string message, Exception inner) : base(message, inner) { }

        override public string Message => "Not In Stock";
        override public string ToString() => Message;
    }
}
