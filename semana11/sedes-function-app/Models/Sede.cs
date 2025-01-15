namespace sedes_function_app.Models;

public class Sede
{
    public Guid Id { get; set; }
    public required string NombreSede { get; set; }
    public required string ImagenUrl { get; set; }
}