namespace Usuarios.Domain.Roles;

public interface IRolRepository
{
    Task<Rol?> GetByNameAsync(string rol, CancellationToken cancellationToken = default );
}