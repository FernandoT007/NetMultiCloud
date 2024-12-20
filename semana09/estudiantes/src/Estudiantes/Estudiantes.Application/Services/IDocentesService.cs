namespace Estudiantes.Application.Services;

public interface IDocentesService
{
    Task<bool> DocenteExistsAsync(Guid docenteId, CancellationToken cancellationToken);
}