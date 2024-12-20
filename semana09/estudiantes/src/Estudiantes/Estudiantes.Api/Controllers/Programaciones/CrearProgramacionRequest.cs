namespace Estudiantes.Api.Controllers.Programaciones;

public record CrearProgramacionRequest
(
    Guid CursoId,
    Guid DocenteId
);

