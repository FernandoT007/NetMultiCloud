using Usuarios.Application.Abstractions.Messaging;
using Usuarios.Application.Abstractions.Time;
using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Roles;
using Usuarios.Domain.Usuarios;

namespace Usuarios.Application.Usuarios.CrearUsuario;

internal sealed class CrearUsuarioCommandHandler :
ICommandHandler<CrearUsuarioCommand, Guid>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly NombreUsuarioService _nombreUsuarioService;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IRolRepository _rolRepository;

    public CrearUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, NombreUsuarioService nombreUsuarioService, IDateTimeProvider dateTimeProvider, IRolRepository rolRepository)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _nombreUsuarioService = nombreUsuarioService;
        _dateTimeProvider = dateTimeProvider;
        _rolRepository = rolRepository;
    }

    public async Task<Result<Guid>> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
    {
        var rolObtenido = await _rolRepository.GetByNameAsync(request.RolNombre,cancellationToken);

        if (rolObtenido == null)
        {
            return Result.Failure<Guid>(RolErrores.NoEncontrado);
        }

        var usuario = Usuario.Create(
            new NombresPersona(request.Nombres),
            new ApellidoPaterno(request.ApellidoPaterno),
            new ApellidoMaterno(request.ApellidoMaterno),
            Password.Create(request.Password),
            request.FechaNacimiento.ToUniversalTime(),
            CorreoElectronico.Create(request.Correo).Value,
            new Direccion(
                request.Pais,
                request.Departamento,
                request.Provincia,
                request.Distrito,
                request.Calle
            ),
            rolObtenido.Id,
            _dateTimeProvider.CurrentTime.ToUniversalTime(),
            _nombreUsuarioService
        );

        _usuarioRepository.Add(usuario);

       await _unitOfWork.SaveChangesAsync(cancellationToken);
       return usuario.Id;

    }
}