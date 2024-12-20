namespace Estudiantes.Application.Matriculas.Events;

public sealed record MatriculaUpdateFailedIntegrationEvent(
    Guid CursoId
);