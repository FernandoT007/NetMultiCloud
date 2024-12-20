using Cursos.Domain.Abstractions;

namespace Cursos.Domain.Cursos;

public static class CursoErrors
{
    public static Error NotFound = new (
        "Cursos.NotFound",
        "No existe este curso"
    );

    public static Error NotFounds = new (
        "Cursos.NotFound",
        "No existen cursos registrados"
    );
}