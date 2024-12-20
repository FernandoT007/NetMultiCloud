using Cursos.Application.Cursos.ObtenerCurso;
using Grpc.Core;
using MediatR;

namespace Cursos.Api.gRPC;

public class CursosGrpcService : CursosService.CursosServiceBase
{
    private readonly ISender _sender;

    public CursosGrpcService(ISender sender)
    {
        _sender = sender;
    }

    public override async Task<CursoResponse> CursoExists(CursoRequest request, ServerCallContext context)
    {
        var cursoId = Guid.Parse(request.CursoId);
        var query = new GetCursoQuery(cursoId);
        var resultado = await _sender.Send(query);
        return new CursoResponse {
            Exists = resultado.IsSuccess
        };
    }
}
