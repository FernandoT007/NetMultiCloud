namespace Estudiantes.Application.Services;

public interface ICursosService
{
    Task<bool> CursoExistsAsync(Guid cursoId, CancellationToken cancellationToken);
}