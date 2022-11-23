public class NotExistException:Exception
{
    public override string Message => "missing item";
}
public class doubleException : Exception
{
    public override string Message => "already existing item";
}