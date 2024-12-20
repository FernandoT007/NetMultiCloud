using Estudiantes.Application.Abstractions.Clock;
using Estudiantes.Application.Abstractions.Messaging;
using Estudiantes.Application.Services;
using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Programaciones;

namespace Estudiantes.Application.Programaciones.CrearProgramacion;

internal sealed class CrearProgramacionCommandHandler :
ICommandHandler<CrearProgramacionCommand, Guid>
{

    private readonly IProgramacionRepository _programacionRepository;
    private readonly IDocentesService _docentesService;
    private readonly ICursosService _cursosService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ICacheService _cacheService;

    public CrearProgramacionCommandHandler(
        IProgramacionRepository programacionRepository, 
        IDocentesService docentesService, 
        ICursosService cursosService, 
        IUnitOfWork unitOfWork, 
        IDateTimeProvider dateTimeProvider, 
        ICacheService cacheService)
    {
        _programacionRepository = programacionRepository;
        _docentesService = docentesService;
        _cursosService = cursosService;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
        _cacheService = cacheService;
    }

    public async Task<Result<Guid>> Handle(CrearProgramacionCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = $"curso_{request.CursoId}";
        var cursoExists = await _cacheService.GetCacheValueAsync<bool>(cacheKey);

        if (!cursoExists)
        {
            cursoExists = await _cursosService.CursoExistsAsync(request.CursoId, cancellationToken);
            var expirationTime = TimeSpan.FromMinutes(3);
            await _cacheService.SetCacheValueAsync(cacheKey, cursoExists,expirationTime);
        }
        if (!cursoExists)
        {
            return Result.Failure<Guid>(new Error("CursoNotFound", "Curso no encontrado"));
        }

        if (!await _docentesService.DocenteExistsAsync(request.DocenteId, cancellationToken))
        {
            return Result.Failure<Guid>(new Error("DocenteNotFound", "Docente no encontrado"));
        }

        if (!await _cursosService.CursoExistsAsync(request.CursoId, cancellationToken))
        {
            return Result.Failure<Guid>(new Error("CursoNotFound", "Curso no encontrado"));
        }

        var programacion = Programacion.Create(
            request.CursoId,
            request.DocenteId,
            _dateTimeProvider.CurrentTime
         );

        _programacionRepository.Add(programacion);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return programacion.Id;     
    }
}

