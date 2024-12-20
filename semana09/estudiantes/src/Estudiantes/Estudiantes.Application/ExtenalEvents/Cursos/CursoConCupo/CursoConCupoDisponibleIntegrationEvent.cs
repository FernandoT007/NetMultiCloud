using MediatR;

namespace Estudiantes.Application.ExternalEvents.Cursos.CursoConCupo;

public sealed record CursoConCupoDisponibleIntegrationEvent (Guid MatriculaId): INotification;

