namespace Estudiantes.Application.Services;

public interface IEventBus
{
    void Publish<T>(T @event) where T : class;
}