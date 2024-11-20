using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Roles;

public class Rol : Entity
{
    private Rol(
        Guid id,
        NombreRol? nombreRol, 
        Descripcion? descripcion
        ) : base(id)
    {
        NombreRol = nombreRol;
        Descripcion = descripcion;
    }
    private Rol(){}

    public NombreRol? NombreRol { get; private set; }
    public Descripcion? Descripcion { get; private set; }

    public static Rol Create(
        NombreRol? nombreRol,
        Descripcion? descripcion
    )
    {
        var rol = new Rol(
            new Guid(),
            nombreRol,
            descripcion);
        return rol;
    }
}