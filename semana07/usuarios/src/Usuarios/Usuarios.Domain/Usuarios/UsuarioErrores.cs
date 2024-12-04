using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;

public class UsuarioErrores
{
    
    public static Error YaSeEncuentraActivo = new (
        "Usuario.YaSeEncuentraActivo",
        "El usuario ya se encuentra activo"
    );

      public static Error YaSeEncuentraInactivo = new (
        "Usuario.YaSeEncuentraInactivo",
        "El usuario ya se encuentra inactivo"
    );

}