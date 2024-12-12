using MediatR;
using Microsoft.Extensions.Logging;
using Docentes.Application.Abstractions.Messaging;

namespace Docentes.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
: IPipelineBehavior<TRequest, TResponse>
where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var nameRequest = request.GetType().Name;
        try
        {
            _logger.LogInformation($"Ejecutando commando: {nameRequest}");
            var result = await next();
            _logger.LogInformation($"Comando ejecutado {nameRequest}");
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"El commando {nameRequest} ha tenido errores.");
            throw;
        }
    }
}