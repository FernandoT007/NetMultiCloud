using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Domain.Matriculas;

public static class MatriculaErrors
{
      public static Error NotFound = new(
        " Matricula.NotFound",
        "No existe una matricula con este id"
    );
}