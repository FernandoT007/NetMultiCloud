using Docentes.Domain.Abstractions;

namespace Docentes.Domain.Docentes;

public sealed class Docente : Entity
{
    private Docente() { }

    private Docente(
    Guid id,
    Guid usuarioId,
    Guid especialidadId
    ) : base(id)
    {
        UsuarioId = usuarioId;
        EspecialidadId = especialidadId;
    }

    public Guid UsuarioId { get; private set; }
    public Guid EspecialidadId { get; private set; }

     public static Result<Docente> Create(
        Guid usuarioId,
        Guid especialidadId
    )
    {
        var docente = new Docente(
            Guid.NewGuid(),
          usuarioId,
          especialidadId
        );
        return docente;
    }
}