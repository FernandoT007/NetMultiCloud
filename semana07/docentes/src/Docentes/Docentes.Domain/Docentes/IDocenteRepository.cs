namespace Docentes.Domain.Docentes;

public interface IDocenteRepository
{
    Task<Docente?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Docente docente);
    Task<Docente?> GetByIdUsuarioAsync(Guid idUsuario, CancellationToken cancellationToken = default);

}