using Estudiantes.Application.Abstractions.Messaging;

namespace Estudiantes.Application.Estudiantes.CrearEstudiante;

public record CrearEstudianteCommand
(
    Guid UsuarioId
) : ICommand<Guid> ;