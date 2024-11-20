namespace Usuarios.Api.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }   
}