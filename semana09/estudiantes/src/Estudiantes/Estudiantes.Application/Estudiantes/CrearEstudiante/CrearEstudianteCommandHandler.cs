using Estudiantes.Application.Abstractions.Messaging;
using Estudiantes.Application.Services;
using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Estudiantes;

namespace Estudiantes.Application.Estudiantes.CrearEstudiante;

internal sealed class CrearEstudianteCommandHandler :
ICommandHandler<CrearEstudianteCommand, Guid>
{
    private readonly IEstudianteRepository _estudianteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsuariosService _usuarioService;
   
    public CrearEstudianteCommandHandler(
        IEstudianteRepository estudianteRepository, 
        IUnitOfWork unitOfWork, 
        IUsuariosService usuarioService)
    {
        _estudianteRepository = estudianteRepository;
        _unitOfWork = unitOfWork;
        _usuarioService = usuarioService;
      
    }

    public async Task<Result<Guid>> Handle(CrearEstudianteCommand request, CancellationToken cancellationToken)
    {
        if (!await _usuarioService.UsuarioExistsAsync(request.UsuarioId, cancellationToken))
        {
            return Result.Failure<Guid>(new Error("UsuarioNotFound", "Usuario no encontrado"));
        }

        var estudiante = Estudiante.Create(
            request.UsuarioId
         );

        _estudianteRepository.Add(estudiante.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return estudiante.Value.Id;
    }

     internal static CrearEstudianteCommandHandler CreateInternal(
            IEstudianteRepository estudianteRepository,
            IUnitOfWork unitOfWork,
            IUsuariosService usuarioService)
        {
            return new CrearEstudianteCommandHandler(
                estudianteRepository,
                unitOfWork,
                usuarioService
            );
        }
}