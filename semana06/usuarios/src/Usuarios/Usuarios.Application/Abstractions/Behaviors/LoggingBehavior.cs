using MediatR;
using Microsoft.Extensions.Logging;
using Usuarios.Application.Abstractions.Messaging;

namespace Usuarios.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TReponse>
: IPipelineBehavior<TRequest, TReponse>
where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TReponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TReponse> next, 
        CancellationToken cancellationToken)
    {
        var nameRequest = request.GetType().Name;
        try
        {
            _logger.LogInformation($"Ejecutando command: {nameRequest}");
            var result = await next();
            _logger.LogInformation($"Commando ejecutado: {nameRequest}");
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,$"El commando {nameRequest} ha tenido un error.");
            throw;
        }
    }
}