using MediatR;
using Usuarios.Application.Abstractions.Email;
using Usuarios.Domain.Usuarios;
using Usuarios.Domain.Usuarios.Events;

namespace Usuarios.Application.Usuarios.CrearUsuario;

public class CrearUsuarioCommandDomainEventHandler : INotificationHandler<UserCreateDomainEvent>
{
    private readonly IEmailService _emailService;
    private readonly IUsuarioRepository _usuarioRepository;

    public CrearUsuarioCommandDomainEventHandler(IEmailService emailService, IUsuarioRepository usuarioRepository)
    {
        _emailService = emailService;
        _usuarioRepository = usuarioRepository;
    }

    public async Task Handle(UserCreateDomainEvent notification, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(notification.idUsuario,cancellationToken);
        if (usuario is null)
        {
            return;
        }

        await _emailService.SendAsync(
            usuario.CorreoElectronico!.Value,
            "Bienvenido a Tecylab",
            $"Su usuario es: {usuario.NombreUsuario} y fue creado {usuario.FechaUltimoCambio}."
        );
    }
}