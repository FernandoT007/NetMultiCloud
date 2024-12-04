using Usuarios.Domain.Roles;

namespace Usuarios.Domain.Tests.Roles;

public class RolTests
{
      [Fact]
    public void Create_ShouldInitializeRolCorrectly()
    {
        // Arrange
        var nombreRol = new NombreRol("Admin");
        var descripcion = new Descripcion("Administrador del sistema");

        // Act
        var rol = Rol.Create(nombreRol, descripcion);

        // Assert
        Assert.NotNull(rol);
        Assert.Equal(nombreRol, rol.NombreRol);
        Assert.Equal(descripcion, rol.Descripcion);
    }
}