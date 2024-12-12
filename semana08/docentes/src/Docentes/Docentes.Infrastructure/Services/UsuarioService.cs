using Docentes.Application.Services;

namespace Docentes.Infrastructure.Services;

public class UsuarioService : IUsuarioService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> UsuarioExistAsync(Guid usuarioId, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"usuario/{usuarioId}",cancellationToken);
        return response.IsSuccessStatusCode;
    }
}