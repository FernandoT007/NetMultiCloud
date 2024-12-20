using Estudiantes.Application.Abstractions.Messaging;

namespace Estudiantes.Application.Programaciones.CrearProgramacion;

public record CrearProgramacionCommand(
    Guid CursoId,
    Guid DocenteId
) : ICommand<Guid> ;