using Estudiantes.Application.Services;

namespace Estudiantes.Infrastructure.Services;

public class DocenteService : IDocentesService
{
    private readonly HttpClient _httpClient;

    public DocenteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> DocenteExistsAsync(Guid docenteId, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"docente/{docenteId}", cancellationToken);
        return response.IsSuccessStatusCode;
    }
}