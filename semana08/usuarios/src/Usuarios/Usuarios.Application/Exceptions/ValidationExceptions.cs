namespace Usuarios.Application.Exceptions;

public class ValidationExceptions : Exception
{
    public ValidationExceptions(IEnumerable<ValidationError> errores)
    {
        Errores = errores;
    }

    public IEnumerable<ValidationError> Errores { get;}
}