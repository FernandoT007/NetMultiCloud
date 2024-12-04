using Docentes.Domain.Abstractions;

namespace Docentes.Domain.Docentes;

public static class DocenteErrors
{
      public static Error NotFound = new(
        "Docente.NotFound",
        "No existe un docente con este id"
    );
}