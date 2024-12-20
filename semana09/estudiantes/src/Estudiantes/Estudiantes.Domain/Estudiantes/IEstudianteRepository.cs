namespace Estudiantes.Domain.Estudiantes;

public interface IEstudianteRepository
{
    Task<Estudiante?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Estudiante Estudiante);
}