namespace Usuarios.Api.Controllers.Usuarios;

public record CrearUsuarioRequest
(
    string Password
   ,string Rol
   ,string Nombres
   ,string ApellidoPaterno
   ,string ApellidoMaterno
   ,DateTime FechaNacimiento
   ,string Pais
   ,string Departamento
   ,string Provincia
   ,string Ciudad
   ,string Distrito
   ,string Calle
   ,string CorreoElectronico
);