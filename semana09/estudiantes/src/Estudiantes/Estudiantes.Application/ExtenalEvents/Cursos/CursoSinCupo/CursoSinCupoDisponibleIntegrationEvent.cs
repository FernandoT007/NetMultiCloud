using MediatR;

namespace Estudiantes.Application.ExternalEvents.Cursos.CursoSinCupo;

public sealed record CursoSinCupoDisponibleIntegrationEvent (Guid MatriculaId): INotification;