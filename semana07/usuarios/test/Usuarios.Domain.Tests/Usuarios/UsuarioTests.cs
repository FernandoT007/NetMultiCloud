using Usuarios.Domain.Usuarios;
using Usuarios.Domain.Usuarios.Events;

namespace Usuarios.Domain.Tests.Usuarios;

public class UsuarioTests
{
     [Fact]
    public void Create_ShouldRaiseUserCreatedDomainEvent()
    {
        // Arrange
        var nombre = new NombresPersona("Juan");
        var apellido = new ApellidoPaterno("Pérez");
        var apellidoMaterno = new ApellidoMaterno("López");
        var password = Password.Create("Password123!");
        var correo = CorreoElectronico.Create("juan.perez@example.com").Value;
        var direccion = new Direccion("Perú", "Lima", "Lima", "San Isidro", "Av. Siempre Viva");
        var rolId = Guid.NewGuid();
        var fechaUltimoCambio = DateTime.UtcNow;

        var nombreUsuarioService = new NombreUsuarioService();

        // Act
        var usuario = Usuario.Create(
            nombre,
            apellido,
            apellidoMaterno,
            password,
            DateTime.UtcNow,
            correo,
            direccion,
            rolId,
            fechaUltimoCambio,
            nombreUsuarioService
        );

        // Assert
        Assert.NotNull(usuario);
        Assert.Contains(usuario.GetDomainEvents(), e => e is UserCreateDomainEvent);
    }

    [Fact]
    public void Activar_ShouldChangeEstadoToActivo_WhenEstadoIsInactivo()
    {
        // Arrange
        var usuario = new Usuario();
        usuario.Inactivar(DateTime.UtcNow); // Aseguramos que el estado inicial es Inactivo

        // Act
        var result = usuario.Activar(DateTime.UtcNow);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(UsuarioEstado.Activo, usuario.Estado);
    }
}