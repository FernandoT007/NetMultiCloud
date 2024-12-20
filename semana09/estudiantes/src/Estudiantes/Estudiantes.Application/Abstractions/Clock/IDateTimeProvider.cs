namespace Estudiantes.Application.Abstractions.Clock;

    public interface IDateTimeProvider
    {
        DateTime CurrentTime { get; }
    }
