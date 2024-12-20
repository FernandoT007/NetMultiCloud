using Estudiantes.Application.Abstractions.Messaging;
using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Programaciones;

namespace Estudiantes.Application.Programaciones.GetProgramacion;

public class GetProgramacionQueryHandler : IQueryHandler<GetProgramacionQuery, ProgramacionResponse>
{
    private readonly IProgramacionRepository _programacionRepository;

    public GetProgramacionQueryHandler(IProgramacionRepository programacionRepository)
    {
        _programacionRepository = programacionRepository;
    }

    public async Task<Result<ProgramacionResponse>> Handle(GetProgramacionQuery request, CancellationToken cancellationToken)
    {
        var matriculaResult = await _programacionRepository.GetByIdAsync(request.ProgramacionId, cancellationToken);
        if (matriculaResult == null)
        {
            return Result.Failure<ProgramacionResponse>(ProgramacionErrors.NotFound);
        }
        
        return Result.Success(new ProgramacionResponse(
             matriculaResult.Id,
             matriculaResult.CursoId,
             matriculaResult.DocenteId,
             matriculaResult.FechaUltimoCambio,
             matriculaResult.Estado.ToString()
         ));
    }
}