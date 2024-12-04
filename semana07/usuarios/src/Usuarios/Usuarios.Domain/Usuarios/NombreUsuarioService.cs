namespace Usuarios.Domain.Usuarios;

public class NombreUsuarioService
{
    public NombreUsuario GenerarNombreUsuario(
        ApellidoPaterno apellidoPaterno,
        NombresPersona nombresPersona
    )
    {
        var inicialNombre = nombresPersona.Value.Substring(0, 1);
        var restoNombre = apellidoPaterno.Value.Trim();
        return NombreUsuario.Create(inicialNombre+restoNombre);
    }
}