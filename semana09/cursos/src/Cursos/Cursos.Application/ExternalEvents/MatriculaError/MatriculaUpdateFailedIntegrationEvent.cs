using MediatR;

namespace Cursos.Application.ExternalEvents.Matriculas.MatriculaError;

public sealed record MatriculaUpdateFailedIntegrationEvent(
    Guid CursoId
): INotification;