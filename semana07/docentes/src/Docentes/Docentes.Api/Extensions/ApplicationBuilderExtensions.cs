using Docentes.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Docentes.Api.Middleware;

namespace Docentes.Api.Extensions;

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
}
