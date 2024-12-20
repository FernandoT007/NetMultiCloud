using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Domain.Estudiantes;

public sealed class Estudiante : Entity
{
    public Estudiante(
        Guid id,
         Guid usuarioId
        ):  base(id)
    {
        UsuarioId = usuarioId;
    }
    public Guid UsuarioId { get; private set; }

    public static Result<Estudiante> Create(
        Guid usuarioId
    )
    {
        var estudiante = new Estudiante(
            Guid.NewGuid(),
          usuarioId
        );
        return estudiante; 
    }
   
}
