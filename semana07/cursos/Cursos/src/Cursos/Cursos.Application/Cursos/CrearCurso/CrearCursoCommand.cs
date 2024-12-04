using Cursos.Application.Abstractions.Messaging;
using Cursos.Domain.Cursos;

namespace Cursos.Application.Cursos.CrearCurso;

public record CrearCursoCommand
(
    string NombreCurso,
    string DescripcionCurso,
    int CapacidadCurso
) : ICommand<Guid>;