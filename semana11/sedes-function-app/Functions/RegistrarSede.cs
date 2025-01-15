using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using sedes_function_app.Models;
using sedes_function_app.Services;

namespace sedes_function_app.Functions;

public class RegistrarSede
{
     private readonly SedeService _sedeService;

    public RegistrarSede(SedeService sedeService)
    {
        _sedeService = sedeService;
    }

    [Function("RegistrarSede")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "sedes")] HttpRequestData req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonSerializer.Deserialize<SedeRequest>(requestBody);

        if (data == null)
        {
            var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
            await badRequest.WriteStringAsync("Datos incompletos.");
            return badRequest;
        }

        var sede = await _sedeService.RegistrarSedeAsync(data);

        var response = req.CreateResponse(HttpStatusCode.Created);
        await response.WriteAsJsonAsync(sede);
        return response;
    }
}