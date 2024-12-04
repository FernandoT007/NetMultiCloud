using Docentes.Domain.Abstractions;
using Docentes.Domain.CursosImpartidos;
using Docentes.Domain.Docentes;
using Docentes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Docentes.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration
   )
    {
        var connectionStringPostgres = configuration.GetConnectionString("Database")
        ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseNpgsql(connectionStringPostgres).UseSnakeCaseNamingConvention(); // usuario, producto_detalle
            }
        );

        services.AddScoped<IDocenteRepository, DocenteRepository>();
        services.AddScoped<ICursoImpartidoRepository, CursoImpartidoRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}