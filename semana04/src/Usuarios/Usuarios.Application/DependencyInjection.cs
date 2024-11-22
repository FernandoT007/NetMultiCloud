using Microsoft.Extensions.DependencyInjection;
using Usuarios.Domain.Usuarios;

namespace Usuarios.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services){
        services.AddMediatR( configuration =>
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
        );

        services.AddTransient<NombreUsuarioService>();
        return services;
    }
}