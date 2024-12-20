using MediatR;

namespace Cursos.Application.ExternalEvents.Matriculas.MatriculaCreada;

public sealed record MatriculaCreatedIntegrationEvent(Guid MatriculaId, Guid CursoId) : INotification;
