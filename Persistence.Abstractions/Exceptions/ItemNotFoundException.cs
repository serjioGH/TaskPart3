namespace Persistence.Abstractions.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string message)
     : base(message)
    {
    }

    public ItemNotFoundException(string message, Exception exc)
    : base(message, exc)
    {
    }
}