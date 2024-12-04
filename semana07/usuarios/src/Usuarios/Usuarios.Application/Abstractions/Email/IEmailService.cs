namespace Usuarios.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(string correo, string subject, string body);
}