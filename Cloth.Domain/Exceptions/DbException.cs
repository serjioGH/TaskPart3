namespace Cloth.Domain.Exceptions;

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