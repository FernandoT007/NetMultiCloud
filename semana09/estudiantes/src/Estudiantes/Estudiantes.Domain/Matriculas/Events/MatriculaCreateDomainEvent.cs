using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Domain.Matriculas.Events;

public sealed record MatriculaCreateDomainEvent(Guid MatriculaId) : IDomainEvent;