using Cursos.Application.Cursos.ObtenerCurso;

namespace Cursos.Application.Cursos.ObtenerCursos;

public sealed record ListCursosResponse
(
    IEnumerable<CursoResponse>? Cursos
);