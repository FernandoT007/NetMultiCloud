using Docentes.api.Controllers.Docentes;
using Estudiantes.Application.Matriculas.CrearMatricula;
using Estudiantes.Application.Matriculas.GetMatricula;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes.api.Controllers.Estudiantes;

[ApiController]
[Route("api/matricula")]
public class MatriculaController  : ControllerBase
{
    private readonly ISender _sender;

    public MatriculaController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerMatricula(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetMatriculaQuery(id);
        var resultado = await _sender.Send(query,cancellationToken);
        return resultado.IsSuccess ? Ok(resultado) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CrearMatricula(
         CrearMatriculaRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearMatriculaCommand
        (
            request.EstudianteId,
            request.ProgramacionId
        );

        var resultado = await _sender.Send(command,cancellationToken);

        if (resultado.IsSuccess)
        {
            return CreatedAtAction(nameof(ObtenerMatricula), new { id = resultado.Value } , resultado.Value );
        }
        return BadRequest(resultado.Error);
    }
}