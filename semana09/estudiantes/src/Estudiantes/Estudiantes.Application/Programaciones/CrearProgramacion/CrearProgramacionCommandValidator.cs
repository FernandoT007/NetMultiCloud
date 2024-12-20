using FluentValidation;

namespace Estudiantes.Application.Programaciones.CrearProgramacion;

public class CrearProgramacionCommandValidator: AbstractValidator<CrearProgramacionCommand>
{
    public CrearProgramacionCommandValidator()
    {
        RuleFor(d => d.CursoId).NotEmpty();
        RuleFor(d => d.DocenteId).NotEmpty();
    }
}