namespace Estudiantes.Domain.Matriculas;

public interface IMatriculaRepository
{
    Task<Matricula?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Matricula?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Matricula Matricula);
    void Update(Matricula Matricula);
}