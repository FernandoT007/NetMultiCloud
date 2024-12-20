using FluentValidation;

namespace Estudiantes.Application.Matriculas.CrearMatricula;

public class CrearMatriculaCommandValidator : AbstractValidator<CrearMatriculaCommand>
{
    public CrearMatriculaCommandValidator()
    {
        RuleFor(d => d.EstudianteId).NotEmpty();
        RuleFor(d => d.ProgramacionId).NotEmpty();
    }
}