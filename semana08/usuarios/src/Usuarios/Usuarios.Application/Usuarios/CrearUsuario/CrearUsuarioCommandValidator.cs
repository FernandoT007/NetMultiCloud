using FluentValidation;

namespace Usuarios.Application.Usuarios.CrearUsuario;

public class CrearUsuarioCommandValidator : AbstractValidator<CrearUsuarioCommand>
{
    public CrearUsuarioCommandValidator()
    {
        RuleFor( u => u.Correo ).NotEmpty().WithMessage("El correo no puede ser vacio.");
        RuleFor( u => u.Nombres ).NotEmpty().WithMessage("El nombre no puede ser vacio.");
        RuleFor( u => u.ApellidoPaterno ).NotEmpty();
        RuleFor( u => u.FechaNacimiento ).LessThan(DateTime.Now).WithMessage("La fecha de nacimiento no puede ser futura");
    }
}