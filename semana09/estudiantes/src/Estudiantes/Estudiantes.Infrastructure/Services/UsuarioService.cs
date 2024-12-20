using Estudiantes.Application.Services;

namespace Estudiantes.Infrastructure.Services;

public class UsuarioService : IUsuariosService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<bool> UsuarioExistsAsync(Guid usuarioId, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"usuario/{usuarioId}", cancellationToken);
        return response.IsSuccessStatusCode;
    }
}