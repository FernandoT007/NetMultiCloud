namespace Cursos.Api.Controllers.Cursos;

public record CrearCursoRequest
(
    string? Nombre,
    string? Descripcion,
    int Capacidad
);