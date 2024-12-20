using Estudiantes.Application.Abstractions.Clock;
using Estudiantes.Application.Abstractions.Messaging;
using Estudiantes.Application.Matriculas.CrearMatricula;
using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Estudiantes;
using Estudiantes.Domain.Matriculas;
using Estudiantes.Domain.Programaciones;

namespace Estudiantes.Application.Estudiantes.CrearEstudiante;

internal sealed class CrearMatriculaCommandHandler :
ICommandHandler<CrearMatriculaCommand, Guid>
{
    private readonly IMatriculaRepository _matriculaRepository;
    private readonly IEstudianteRepository _estudianteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProgramacionRepository _programacionRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CrearMatriculaCommandHandler(
        IMatriculaRepository matriculaRepository, 
        IEstudianteRepository estudianteRepository, 
        IUnitOfWork unitOfWork, 
        IProgramacionRepository programacionRepository, 
        IDateTimeProvider dateTimeProvider)
    {
        _matriculaRepository = matriculaRepository;
        _estudianteRepository = estudianteRepository;
        _unitOfWork = unitOfWork;
        _programacionRepository = programacionRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(CrearMatriculaCommand request, CancellationToken cancellationToken)
    {
        if (await _estudianteRepository.GetByIdAsync(request.EstudianteId, cancellationToken) is null)
        {
            return Result.Failure<Guid>(new Error("EstudianteNotFound", "Estudiante no encontrado"));
        }
        if (await _programacionRepository.GetByIdAsync(request.ProgramacionId, cancellationToken) is null )
        {
            return Result.Failure<Guid>(ProgramacionErrors.NotFound);
        }

        var matricula = Matricula.Create(
            request.EstudianteId,
            request.ProgramacionId,
            _dateTimeProvider.CurrentTime
         );

        _matriculaRepository.Add(matricula.Value); 

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return matricula.Value.Id;
    }
}