using Estudiantes.Application.Abstractions.Messaging;
using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Estudiantes;

namespace Estudiantes.Application.Estudiantes.GetEstudiante;

internal sealed class GetEstudianteQueryHandler : IQueryHandler<GetEstudianteQuery, EstudianteResponse>
{
    private readonly IEstudianteRepository _estudianteRepository;

    public GetEstudianteQueryHandler(IEstudianteRepository estudianteRepository)
    {
        _estudianteRepository = estudianteRepository;
    }

   
    public async Task<Result<EstudianteResponse>> Handle(GetEstudianteQuery request, CancellationToken cancellationToken)
    {
        var estudianteResult = await _estudianteRepository.GetByIdAsync(request.EstudianteId, cancellationToken);
        if (estudianteResult == null)
        {
            return Result.Failure<EstudianteResponse>(EstudianteErrors.NotFound);
        }
        
        return Result.Success(new EstudianteResponse(
             estudianteResult.Id,
             estudianteResult.UsuarioId
         ));
    }
}