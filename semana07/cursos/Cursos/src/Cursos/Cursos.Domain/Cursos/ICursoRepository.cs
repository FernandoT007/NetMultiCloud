namespace Cursos.Domain.Cursos;

public interface ICursoRepository
{
    Task<Curso> GetByIdAsync(Guid id, CancellationToken cancellationToken= default);
    Task AddAsync(Curso curso, CancellationToken cancellationToken= default);
    Task<List<Curso>> GetCursos(CancellationToken cancellationToken= default);
}