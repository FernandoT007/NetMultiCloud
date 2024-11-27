namespace Usuarios.Domain.Usuarios;

public record NombreUsuario
{
    public string Value { get; init; }

    private NombreUsuario(string value)
    {
        Value = value;
    }

    public static NombreUsuario Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El nombre de usuario no puede estar vacío.", nameof(value));
        }
        return new NombreUsuario(value);
    }

}