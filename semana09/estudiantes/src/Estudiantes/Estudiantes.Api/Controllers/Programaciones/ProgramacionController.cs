using Estudiantes.Application.Programaciones.CrearProgramacion;
using Estudiantes.Application.Programaciones.GetProgramacion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes.Api.Controllers.Programaciones;


[ApiController]
[Route("api/programacion")]
public class ProgramacionController : ControllerBase
{
    private readonly ISender _sender;

    public ProgramacionController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerProgramacion(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetProgramacionQuery(id);
        var resultado = await _sender.Send(query, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CrearProgramacion(
        CrearProgramacionRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearProgramacionCommand
        (
          request.CursoId,
          request.DocenteId
        );

        var resultado = await _sender.Send(command, cancellationToken);

        if (resultado.IsSuccess)
        {
            return CreatedAtAction(nameof(ObtenerProgramacion), new { id = resultado.Value }, resultado.Value);
        }
        return BadRequest(resultado.Error);
    }
}