using Estudiantes.Application.Abstractions.Messaging;
using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Matriculas;

namespace Estudiantes.Application.Matriculas.GetMatricula;

internal sealed class GetMatriculaQueryHandler : IQueryHandler<GetMatriculaQuery, MatriculaResponse>
{
    private readonly IMatriculaRepository _matriculaRepository;

    public GetMatriculaQueryHandler(IMatriculaRepository matriculaRepository)
    {
        _matriculaRepository = matriculaRepository;
    }

    public async Task<Result<MatriculaResponse>> Handle(GetMatriculaQuery request, CancellationToken cancellationToken)
    {
        var matriculaResult = await _matriculaRepository.GetByIdAsync(request.MatriculaId, cancellationToken);
        if (matriculaResult == null)
        {
            return Result.Failure<MatriculaResponse>(MatriculaErrors.NotFound);
        }
        
        return Result.Success(new MatriculaResponse(
             matriculaResult.Id,
             matriculaResult.EstudianteId,
             matriculaResult.ProgramacionId,
             matriculaResult.FechaMatricula,
             matriculaResult.EstadoMatricula.ToString()
         ));
    }
}