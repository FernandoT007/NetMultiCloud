namespace Docentes.Application.Services;

public interface ICursosService
{
    Task<bool> CursoExistAsync(Guid cursoId, CancellationToken cancellationToken);
}