namespace Docentes.Domain.CursosImpartidos;

public interface ICursoImpartidoRepository
{
    Task<CursoImpartido?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(CursoImpartido usuario);
}