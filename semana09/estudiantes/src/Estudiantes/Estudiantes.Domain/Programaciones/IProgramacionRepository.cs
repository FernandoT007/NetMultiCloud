namespace Estudiantes.Domain.Programaciones;

public interface IProgramacionRepository
{
    Task<Programacion?> GetByIdAsync(Guid id, CancellationToken cancellationToken= default);

    void Add(Programacion programacion);

    void Update(Programacion programacion);
}