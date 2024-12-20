using FluentValidation;

namespace Cursos.Application.Cursos.CrearCurso;

public class CrearCursoCommandValidator : AbstractValidator<CrearCursoCommand>
{
    public CrearCursoCommandValidator()
    {
        RuleFor(c => c.NombreCurso).NotEmpty().WithMessage("El nombre del curso no puede ser vacio");
        RuleFor(c => c.DescripcionCurso).NotEmpty();
        RuleFor(c => c.CapacidadCurso).GreaterThan(0);

    }
}