namespace Cursos.Application.Cursos.ObtenerCurso;

public sealed record CursoResponse
(
    Guid IdCurso,
    string NombreCurso,
    string DescripcionCurso,
    int CapacidadCurso
);