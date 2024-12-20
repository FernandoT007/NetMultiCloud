using Cursos.Application.Abstractions.Messaging;

namespace Cursos.Application.Cursos.CrearCurso;

public record CrearCursoCommand
(
    string NombreCurso,
    string DescripcionCurso,
    int CapacidadCurso
) : ICommand<Guid>;