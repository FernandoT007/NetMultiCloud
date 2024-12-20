using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Domain.Estudiantes;

public static class EstudianteErrors
{
      public static Error NotFound = new(
        "Estudiante.NotFound",
        "No existe un Estudiante con este id"
    );
}