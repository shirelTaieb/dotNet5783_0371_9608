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
    public class worngDataException : Exception
    {
        public worngDataException() : base() { }
        public worngDataException(string message) : base(message) { }
        public worngDataException(string message, Exception inner) : base(message, inner) { }

        override public string Message => "The Data you ender is invalide";
        override public string ToString() => Message;
    }
}

