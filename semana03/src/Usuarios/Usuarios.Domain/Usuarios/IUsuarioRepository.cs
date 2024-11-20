namespace Usuarios.Domain.Usuarios;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Usuario usuario);

    void Delete(Usuario usuario);

    Task<bool> ExisteCorreoAsync(CorreoElectronico correo, CancellationToken cancellationToken = default);

}