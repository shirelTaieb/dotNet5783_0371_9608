using System.Runtime.Serialization;

[Serializable]
public class doubleException : Exception
{
    public doubleException() : base() { }
    public doubleException(string message) : base(message) { }
    public doubleException(string message, Exception inner) : base(message, inner) { }

    override public string Message => "already existing item";
    override public string ToString() => Message;
}
[Serializable]
public class NotExistException : Exception
{
    public NotExistException() : base() { }
    public NotExistException(string message) : base(message) { }
    public NotExistException(string message, Exception inner) : base(message, inner) { }
    override public string Message => "missing item";
    override public string ToString() =>Message;
}