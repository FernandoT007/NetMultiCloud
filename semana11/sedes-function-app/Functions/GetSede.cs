using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using sedes_function_app.Services;

namespace sedes_function_app.Functions;

public class GetSede
{
    private readonly SedeService _sedeService;

    public GetSede(SedeService sedeService)
    {
        _sedeService = sedeService;
    }

    [Function("GetSede")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "sedes/{id}")] HttpRequestData req, Guid id)
    {
        var sede = await _sedeService.GetSedeByIdAsync(id);

        if (sede == null)
        {
            var notFound = req.CreateResponse(HttpStatusCode.NotFound);
            await notFound.WriteStringAsync("Sede no encontrada.");
            return notFound;
        }

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(sede);
        return response;
    }
}