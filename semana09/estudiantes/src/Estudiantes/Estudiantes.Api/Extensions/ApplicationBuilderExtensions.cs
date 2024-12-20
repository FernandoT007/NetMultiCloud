using Estudiantes.Api.Middleware;
using Estudiantes.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Estudiantes.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async void ApplyMigrations(this IApplicationBuilder app)
    {
        using(var scope = app.ApplicationServices.CreateScope())
        {
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = service.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex,"Error en la migracion");
            }

        }
    }
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    } 

    public static IApplicationBuilder UseRateLimiter(
        this IApplicationBuilder app,
        int requestLimit,
        TimeSpan timeSpan)
        {
            return app.UseMiddleware<RateLimitingMiddleware>(
                app.ApplicationServices.GetRequiredService<ILogger<RateLimitingMiddleware>>(),
                app.ApplicationServices.GetRequiredService<IMemoryCache>(),
                requestLimit,
                timeSpan
            );
        }
    
}