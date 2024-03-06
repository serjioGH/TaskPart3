namespace Persistence.Abstractions.Exceptions;

public class DbException : Exception
{
    public DbException(string message)
     : base(message)
    {
    }

    public DbException(string message, Exception exc)
    : base(message, exc)
    {
    }
}