using Docentes.Application.Abstractions.Messaging;
using Docentes.Application.Services;
using Docentes.Domain.Abstractions;
using Docentes.Domain.Docentes;

namespace Docentes.Application.Docentes.CrearDocente;

internal sealed class CrearDocenteCommandHandler :
ICommandHandler<CrearDocenteCommand, Guid>
{
    private readonly IDocenteRepository _docenteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsuarioService _usuarioService;
    private readonly ICursosService _cursosService;
    private readonly ICacheService _cacheService;

    public CrearDocenteCommandHandler(IDocenteRepository docenteRepository, IUnitOfWork unitOfWork, IUsuarioService usuarioService, ICursosService cursosService, ICacheService cacheService)
    {
        _docenteRepository = docenteRepository;
        _unitOfWork = unitOfWork;
        _usuarioService = usuarioService;
        _cursosService = cursosService;
        _cacheService = cacheService;
    }

    public async Task<Result<Guid>> Handle(CrearDocenteCommand request, CancellationToken cancellationToken)
    {
        if (!await _usuarioService.UsuarioExistAsync(request.UsuarioId,cancellationToken))
        {
            return Result.Failure<Guid>(new Error("UsuarioNotFound","El usuarioId no es valido"));
        }

        var cacheKey = $"curso_{request.EspecialidadId}";
        var cursoExist = await _cacheService.GetCacheValueAsync<bool>(cacheKey);

        if (!cursoExist)
        {
            cursoExist = await _cursosService.CursoExistAsync(request.EspecialidadId,cancellationToken);
            var expirationTime = TimeSpan.FromMinutes(3);
            await _cacheService.SetCacheValueAsync(cacheKey,cursoExist,expirationTime);
        }

        if (!cursoExist)
        {
            return Result.Failure<Guid>(new Error("CursoNotFound","El especialidadId no es valido"));
        }

        var docente = Docente.Create(
            request.UsuarioId,
            request.EspecialidadId
        );

        _docenteRepository.Add(docente.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return docente.Value.Id;
    }
}