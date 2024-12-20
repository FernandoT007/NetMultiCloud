namespace Estudiantes.Application.Programaciones.GetProgramacion;

public record ProgramacionResponse
(
    Guid Id,
    Guid CursoId,
    Guid DocenteId,
    DateTime FechaUltimoCambio,
    string Estado
);