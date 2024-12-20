using FluentValidation;

namespace Estudiantes.Application.Estudiantes.CrearEstudiante;

public class CrearEstudianteCommandValidator : AbstractValidator<CrearEstudianteCommand>
{
    public CrearEstudianteCommandValidator()
    {
        RuleFor(d => d.UsuarioId)
            .Must(guid => Guid.TryParse(guid.ToString() , out _))
            .WithMessage("El ID de usuario debe ser un Guid válido");
    }
}