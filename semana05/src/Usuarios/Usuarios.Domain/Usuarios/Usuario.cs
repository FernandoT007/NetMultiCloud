using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Roles;
using Usuarios.Domain.Usuarios.Events;

namespace Usuarios.Domain.Usuarios;

public class Usuario : Entity
{
    public Usuario () {}

    private Usuario(
        Guid id,
        NombreUsuario nombreUsuario, 
        NombresPersona nombresPersona, 
        ApellidoPaterno apellidoPaterno, 
        ApellidoMaterno apellidoMaterno, 
        Password password, 
        DateTime fechaNacimiento, 
        CorreoElectronico correoElectronico, 
        Direccion direccion, 
        UsuarioEstado estado, 
        Guid rolId,
        DateTime fechaUltimoCambio) : base(id)
    {
        NombreUsuario = nombreUsuario;
        NombresPersona = nombresPersona;
        ApellidoPaterno = apellidoPaterno;
        ApellidoMaterno = apellidoMaterno;
        Password = password;
        FechaNacimiento = fechaNacimiento;
        CorreoElectronico = correoElectronico;
        Direccion = direccion;
        Estado = estado;
        RolId = rolId;
        FechaUltimoCambio = fechaUltimoCambio;
    }

    public NombreUsuario? NombreUsuario { get; private set; }
    public NombresPersona? NombresPersona { get; private set; }
    public ApellidoPaterno? ApellidoPaterno { get; private set; }
    public ApellidoMaterno? ApellidoMaterno { get; private set; }
    public Password? Password { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public CorreoElectronico? CorreoElectronico { get; private set; }
    public Direccion? Direccion { get; private set; }
    public UsuarioEstado Estado { get; private set; }
    public DateTime FechaUltimoCambio { get; private set; }
    public Guid RolId { get; private set; }
    public Rol? Rol { get; private set; }

    public static Usuario Create(
        NombresPersona nombresPersona, 
        ApellidoPaterno apellidoPaterno, 
        ApellidoMaterno apellidoMaterno, 
        Password password, 
        DateTime fechaNacimiento, 
        CorreoElectronico correoElectronico, 
        Direccion direccion, 
        Guid rolId,
        DateTime fechaUltimoCambio,
        NombreUsuarioService nombreUsuarioService)
    {

        var nombreUsuario = nombreUsuarioService.GenerarNombreUsuario(apellidoPaterno, nombresPersona);

         var usuario = new Usuario(
            Guid.NewGuid(),
            nombreUsuario,
            nombresPersona,
            apellidoPaterno,
            apellidoMaterno,
            password,
            fechaNacimiento,
            correoElectronico,
            direccion,
            UsuarioEstado.Activo,
            rolId,
            fechaUltimoCambio);

            usuario.RaiseDomainEvent(new UserCreateDomainEvent(usuario.Id));

            return usuario;
    }

    public Result Activar(DateTime utcNow)
    {
        if (Estado == UsuarioEstado.Activo)
        {
            return Result.Failure(UsuarioErrores.YaSeEncuentraActivo);
        }
        Estado = UsuarioEstado.Activo;
        FechaUltimoCambio = utcNow;

        return Result.Success();
    }

     public Result Inactivar(DateTime utcNow)
    {
        if (Estado == UsuarioEstado.Inactivo)
        {
            return Result.Failure(UsuarioErrores.YaSeEncuentraInactivo);
        }
        Estado = UsuarioEstado.Inactivo;
        FechaUltimoCambio = utcNow;

        return Result.Success();
    }

}