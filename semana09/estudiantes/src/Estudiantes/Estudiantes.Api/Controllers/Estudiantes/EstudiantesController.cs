using Estudiantes.Api.Atributos;
using Estudiantes.Api.Controllers.Estudiantes;
using Estudiantes.Application.Estudiantes.CrearEstudiante;
using Estudiantes.Application.Estudiantes.GetEstudiante;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes.api.Controllers.CursosImpartidos;

[ApiController]
[Route("api/estudiantes")]
public class EstudiantesController : ControllerBase
{
    private readonly ISender _sender;

    public EstudiantesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    [RateLimit(5,60)]
    public async Task<IActionResult> ObtenerEstudiante(
      Guid id,
      CancellationToken cancellationToken
    )
    {
        var query = new GetEstudianteQuery(id);
        var resultado = await _sender.Send(query, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CrearEstudiante(
       CrearEstudianteRequest request,
       CancellationToken cancellationToken
    )
    {
        var command = new CrearEstudianteCommand
        (
            request.UsuarioId
        );

        var resultado = await _sender.Send(command, cancellationToken);

        if (resultado.IsSuccess)
        {
            return CreatedAtAction(nameof(ObtenerEstudiante), new { id = resultado.Value }, resultado.Value);
        }
        return BadRequest(resultado.Error);
    }


}