using Usuarios.Application.Abstractions.Email;

namespace Usuarios.Infrastructure.Abstractions.Email;

public class EmailService : IEmailService
{
    public Task SendAsync(string correo, string subject, string body)
    {
        return Task.CompletedTask;
    }
}