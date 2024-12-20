using Estudiantes.Application.Services;

namespace Estudiantes.Infrastructure.Services;

public class CursoService : ICursosService
{
    private readonly HttpClient _httpClient;

    public CursoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> CursoExistsAsync(Guid cursoId, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"cursos/{cursoId}", cancellationToken);
        return response.IsSuccessStatusCode;
    }
}