namespace Estudiantes.Application.Services;

public interface IUsuariosService
{
     Task<bool> UsuarioExistsAsync(Guid usuarioId, CancellationToken cancellationToken);
}
