namespace Cursos.Application.Exceptions;

public class ValidationExceptions : Exception
{
    public IEnumerable<ValidationError> Errors { get; }

    public ValidationExceptions(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }
}