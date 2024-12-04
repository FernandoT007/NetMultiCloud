using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Docentes.api.Controllers.CursosImpartidos;

[ApiController]
[Route("api/cursosImpartidos")]
public class CursosImpartidosController  : ControllerBase
{
    private readonly ISender _sender;

    public CursosImpartidosController(ISender sender)
    {
        _sender = sender;
    }

}