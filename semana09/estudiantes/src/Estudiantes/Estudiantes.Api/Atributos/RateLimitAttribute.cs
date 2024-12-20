using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace Estudiantes.Api.Atributos;

public class RateLimitAttribute : Attribute, IAsyncActionFilter
{
    private readonly int _requestLimit;
    private readonly TimeSpan _timeSpan;

    public RateLimitAttribute(int requestLimit, int seconds)
    {
        _requestLimit = requestLimit;
        _timeSpan = TimeSpan.FromSeconds(seconds);
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var clientIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();

        if (clientIp != null)
        {
            var cacheKey = $"RateLimit_{clientIp}";
            var cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
            var logger = context.HttpContext.RequestServices.GetService<ILogger<RateLimitAttribute>>();

            if (!cache!.TryGetValue(cacheKey, out int requestCount))
            {
                requestCount = 0;
            }
            if (requestCount >= _requestLimit)
            {
               context.Result = new ContentResult
                {
                    StatusCode = 429,
                    Content = "Rate limit excedido. Intentalo luego."
                };
                return;
            }
            requestCount++;
            cache!.Set(cacheKey, requestCount, _timeSpan);

            logger!.LogInformation($"Request {requestCount} from {clientIp}");
        }
        await next();
    }
}