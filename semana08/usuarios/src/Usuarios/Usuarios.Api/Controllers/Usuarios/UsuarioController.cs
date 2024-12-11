using MediatR;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Api.Controllers.Usuarios;
using Usuarios.Application.Usuarios.CrearUsuario;
using Usuarios.Application.Usuarios.GetUsuario;
namespace Usuarios.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{

     private readonly ISender _sender;

    public UsuarioController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(
        Guid id,
        CancellationToken cancellationToken
        )
    {
        var query = new GetUsuarioQuery(id);
        var user = await _sender.Send(query,cancellationToken);
        return user is not null ? Ok(user) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        CrearUsuarioRequest  request,
        CancellationToken cancellationToken)
    {
        var command = new CrearUsuarioCommand(
            request.Password,
            request.Rol,
            request.ApellidoPaterno,
            request.ApellidoMaterno,
            request.Nombres,
            request.FechaNacimiento,
            request.CorreoElectronico,
            request.Pais,
            request.Departamento,
            request.Provincia,
            request.Distrito,
            request.Calle
        );
        var resultado = await _sender.Send(command,cancellationToken);

        if(resultado.IsSuccess)
        {
         return CreatedAtAction(nameof(GetUser), new { id = resultado.Value }, resultado.Value);
        }
        return BadRequest(resultado.Error);

    }
}