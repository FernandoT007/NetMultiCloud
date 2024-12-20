using Microsoft.Extensions.Caching.Memory;

namespace Estudiantes.Api.Middleware;

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RateLimitingMiddleware> _logger;
    private readonly IMemoryCache _cache;
    private readonly int _requestLimit;
    private readonly TimeSpan _timeSpan;

    public RateLimitingMiddleware(RequestDelegate next, ILogger<RateLimitingMiddleware> logger, IMemoryCache cache, int requestLimit, TimeSpan timeSpan)
    {
        _next = next;
        _logger = logger;
        _cache = cache;
        _requestLimit = requestLimit;
        _timeSpan = timeSpan;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var clientIp = context.Connection.RemoteIpAddress?.ToString();

        if (clientIp != null)
        {
            var cacheKey = $"RateLimit_{clientIp}";
            if (!_cache.TryGetValue(cacheKey, out int requestCount))
            {
                requestCount = 0;
            }
            if (requestCount >= _requestLimit)
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.Response.WriteAsync("Rate limite excedido. Intentalo luego.");
                return;
            }
            requestCount++;
            _cache.Set(cacheKey, requestCount, _timeSpan);
            _logger.LogInformation($"Request {requestCount} from {clientIp}");
        }
        await _next(context);
    }
}
