using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Roles;

public static class RolErrores
{
    public static Error NoEncontrado = new 
    (
        "Rol.NoEncontrado",
        "No se encontro el rol"
    );
}