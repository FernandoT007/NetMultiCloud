namespace Docentes.Application.Services;

public interface IUsuarioService
{
    Task<bool> UsuarioExistAsync(Guid usuarioId, CancellationToken cancellationToken);
}