namespace Docentes.Application.Exceptions;

public sealed class ConcurrencyException : Exception
{
    
    public ConcurrencyException(string message, Exception exception)
    :base (message,exception)
    {
        
    }
}