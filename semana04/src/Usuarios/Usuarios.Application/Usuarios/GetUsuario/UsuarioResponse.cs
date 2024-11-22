namespace Usuarios.Application.Usuarios.GetUsuario;

public sealed record UsuarioResponse
(
    Guid Id,
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
    string Calle,
    string Estado,
    DateTime FechaUltimoCambio,
    string Rol
);