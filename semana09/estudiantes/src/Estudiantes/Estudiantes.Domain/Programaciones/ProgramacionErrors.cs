using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Domain.Programaciones;

public static class ProgramacionErrors
{
     public static Error NotFound = new(
        "Programacion.NotFound",
        "No existe una programacion con este id"
    );
}