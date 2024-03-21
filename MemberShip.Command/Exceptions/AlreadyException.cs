namespace MemberShip.Command.Exceptions;
public class AlreadyException : Exception
{
    public AlreadyException(string message) : base(message) { }
}