using FluentValidation;

namespace Docentes.Application.Docentes.CrearDocente;

public class CrearDocenteCommandValidator : AbstractValidator<CrearDocenteCommand>
{
    public CrearDocenteCommandValidator()
    {
        RuleFor(c => c.EspecialidadId)
            .Must(guid => Guid.TryParse(guid.ToString() , out _))
            .WithMessage("El ID de de la especialidad debe ser un Guid válido");;

        RuleFor(c => c.UsuarioId)
            .Must(guid => Guid.TryParse(guid.ToString() , out _))
            .WithMessage("El ID de usuario debe ser un Guid válido");;
    }
}