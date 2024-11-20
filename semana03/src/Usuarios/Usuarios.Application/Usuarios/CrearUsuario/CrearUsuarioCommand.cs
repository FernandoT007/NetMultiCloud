using Usuarios.Application.Abstractions.Messaging;

namespace Usuarios.Application.Usuarios.CrearUsuario;

public sealed record CrearUsuarioCommand
(
    string Password,
    string RolNombre,
    string ApellidoPaterno,
    string ApellidoMaterno,
    string Nombres,
    DateTime FechaNacimiento,
    string Correo,
    string Pais,
    string Departamento,
    string Provincia,
    string Distrito,
    string Calle
) : ICommand<Guid>;