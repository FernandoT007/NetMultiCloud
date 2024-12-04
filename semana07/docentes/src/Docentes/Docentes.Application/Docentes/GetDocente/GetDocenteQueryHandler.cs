using Docentes.Application.Abstractions.Messaging;
using Docentes.Domain.Abstractions;
using Docentes.Domain.Docentes;

namespace Docentes.Application.Docentes.GetDocente;

internal sealed class GetDocenteQueryHandler : IQueryHandler<GetDocenteQuery, DocenteResponse>
{
    private readonly IDocenteRepository _docenteRepository;

    public GetDocenteQueryHandler(IDocenteRepository docenteRepository)
    {
        _docenteRepository = docenteRepository;
    }

    public async Task<Result<DocenteResponse>> Handle(GetDocenteQuery request, CancellationToken cancellationToken)
    {
        var docenteResult = await _docenteRepository.GetByIdAsync(request.DocenteId, cancellationToken);
        if (docenteResult == null)
        {
            return Result.Failure<DocenteResponse>(DocenteErrors.NotFound);
        }
        
        return Result.Success(new DocenteResponse(
             docenteResult.Id,
             docenteResult.UsuarioId,
             docenteResult.EspecialidadId
         ));
    }
}