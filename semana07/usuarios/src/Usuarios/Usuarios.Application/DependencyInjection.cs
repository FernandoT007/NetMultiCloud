using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Usuarios.Application.Abstractions.Behaviors;
using Usuarios.Domain.Usuarios;

namespace Usuarios.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient<NombreUsuarioService>();
        return services;
    }
}