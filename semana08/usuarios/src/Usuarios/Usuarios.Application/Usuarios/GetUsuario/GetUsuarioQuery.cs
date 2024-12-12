using Usuarios.Application.Abstractions.Messaging;

namespace Usuarios.Application.Usuarios.GetUsuario;

public sealed record GetUsuarioQuery(Guid IdUsuario) : IQuery<UsuarioResponse>;