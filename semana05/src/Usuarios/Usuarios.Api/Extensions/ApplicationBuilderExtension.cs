using Microsoft.EntityFrameworkCore;
using Usuarios.Api.Middleware;
using Usuarios.Infrastructure;

namespace Usuarios.Api.Extensions;

public static class ApplicationBuilderExtension
{
    public static async void ApplyMigrations(
        this IApplicationBuilder app
    )
    {
        using (var scope = app.ApplicationServices.CreateScope())
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
                logger.LogError(ex,"Error en la migracion de la capa de dominio a la base de datos");
                throw;
            }

        }
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}