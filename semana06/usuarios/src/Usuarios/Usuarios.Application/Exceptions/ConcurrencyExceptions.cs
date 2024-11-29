namespace Usuarios.Application.Exceptions;

public sealed class ConcurrencyExceptions : Exception
{
    public ConcurrencyExceptions(string message, Exception exception) :
    base (message , exception)
    {

    }
}