using Docentes.Application.Abstractions.Messaging;

namespace Docentes.Application.Docentes.CrearDocente;

public record CrearDocenteCommand
(
   Guid usuarioId,
    Guid especialidadId
) : ICommand<Guid> ;