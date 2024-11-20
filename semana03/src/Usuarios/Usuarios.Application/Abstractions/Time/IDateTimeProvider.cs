namespace Usuarios.Application.Abstractions.Time;

public interface IDateTimeProvider
{
    DateTime CurrentTime { get; }
}