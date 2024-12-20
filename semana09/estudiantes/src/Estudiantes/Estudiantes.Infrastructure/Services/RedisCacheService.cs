using System.Text.Json;
using Estudiantes.Application.Services;
using StackExchange.Redis;

namespace Estudiantes.Infrastructure.Services;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<T?> GetCacheValueAsync<T>(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        var value = await db.StringGetAsync(key);

        if (value.IsNullOrEmpty)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(value!);
    }
     public async Task SetCacheValueAsync<T>(string key, T value, TimeSpan? expirationTime = null)
    {
        var db = _connectionMultiplexer.GetDatabase();
        var json = JsonSerializer.Serialize(value);

        await db.StringSetAsync(key, json, expirationTime);
    }
}