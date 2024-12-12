using Docentes.Application.Docentes.CrearDocente;
using Docentes.Application.Docentes.GetDocente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Docentes.api.Controllers.Docentes;

[ApiController]
[Route("api/docente")]
public class DocenteController  : ControllerBase
{
      private readonly ISender _sender;

    public DocenteController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerDocente(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetDocenteQuery(id);
        var resultado = await _sender.Send(query,cancellationToken);
        return resultado.IsSuccess ? Ok(resultado) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CrearDocente(
         CrearDocenteRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearDocenteCommand
        (
            request.UsuarioId,
            request.EspecialidadId
        );

        var resultado = await _sender.Send(command,cancellationToken);

        if (resultado.IsSuccess)
        {
            return CreatedAtAction(nameof(ObtenerDocente), new { id = resultado.Value } , resultado.Value );
        }
        return BadRequest(resultado.Error);
    }

}