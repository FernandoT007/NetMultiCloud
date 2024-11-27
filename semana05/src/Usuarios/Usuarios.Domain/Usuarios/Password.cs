namespace Usuarios.Domain.Usuarios;

public record Password
{
    public string Value { get; init; }

    public static implicit operator string(Password password) => password.Value;

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || value.Length < 8)
        {
            throw new ApplicationException("El password es invalido");
        }
        return new Password(value);
    }
}