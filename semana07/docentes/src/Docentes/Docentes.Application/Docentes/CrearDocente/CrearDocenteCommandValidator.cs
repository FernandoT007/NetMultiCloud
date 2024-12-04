using FluentValidation;

namespace Docentes.Application.Docentes.CrearDocente;

public class CrearDocenteCommandValidator : AbstractValidator<CrearDocenteCommand>
{
    public CrearDocenteCommandValidator()
    {
        RuleFor(c => c.EspecialidadId)
            .Must(guid => Guid.TryParse(guid.ToString() , out _))
            .WithMessage("El ID de usuario debe ser un Guid válido");;

        RuleFor(c => c.ApellidoPaterno).NotEmpty();
        RuleFor(c => c.ApellidoMaterno).NotEmpty();
        RuleFor(c => c.Nombres).NotEmpty();      
        RuleFor(c => c.FechaNacimiento).LessThan(DateTime.UtcNow.AddYears(-18)).WithMessage("El estudiante debe ser mayor de edad");
        RuleFor(c => c.CorreoElectronico).NotEmpty();
    }
}