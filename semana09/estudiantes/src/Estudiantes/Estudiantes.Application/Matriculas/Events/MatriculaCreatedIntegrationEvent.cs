namespace Estudiantes.Application.Matriculas.Events;

public sealed record MatriculaCreatedIntegrationEvent(
    Guid MatriculaId, 
    Guid CursoId
);