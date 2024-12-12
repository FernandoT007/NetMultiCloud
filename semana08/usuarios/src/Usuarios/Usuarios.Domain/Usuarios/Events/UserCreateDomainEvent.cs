using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios.Events;

public sealed record UserCreateDomainEvent(Guid idUsuario) : IDomainEvent; 