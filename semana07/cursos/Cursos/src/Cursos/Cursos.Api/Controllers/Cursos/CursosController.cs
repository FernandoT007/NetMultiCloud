using Cursos.Application.Cursos.CrearCurso;
using Cursos.Application.Cursos.ObtenerCurso;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cursos.Api.Controllers.Cursos;

[ApiController]
[Route("api/cursos")]
public class CursosController : ControllerBase
{
    private readonly ISender _sender;

    public CursosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CrearCurso
    (
        CrearCursoRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearCursoCommand
        (
            request.Nombre!,
            request.Descripcion!,
            request.Capacidad
        );

        var result = await _sender.Send(command,cancellationToken);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(ObtenerCurso),new { id = result.Value } , result.Value  );
        }
        return BadRequest(result.Error);
    }

     [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerCurso(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetCursoQuery(id);
        var resultado = await _sender.Send(query,cancellationToken);
        return resultado.IsSuccess ?  Ok(resultado) : NotFound();
    }


}