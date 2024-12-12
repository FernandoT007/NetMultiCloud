using Docentes.Application.Abstractions.Messaging;

namespace Docentes.Application.Docentes.CrearDocente;

public record CrearDocenteCommand
(
   Guid UsuarioId,
    Guid EspecialidadId
) : ICommand<Guid> ;