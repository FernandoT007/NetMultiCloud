using System.Text;
using System.Text.Json;
using Cursos.Application.ExternalEvents.Matriculas.MatriculaCreada;
using Cursos.Application.ExternalEvents.Matriculas.MatriculaError;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Cursos.Infrastructure.Services;

public class RabbitMQEventListener : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RabbitMQEventListener> _logger;

    private readonly Dictionary<string, Type> _eventTypeMappings;

    public RabbitMQEventListener(
        IConfiguration configuration,
        IServiceProvider serviceProvider,
        ILogger<RabbitMQEventListener> logger)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;

        var factory = new ConnectionFactory()
        {
            Uri = new Uri(configuration["UrlRabbit"]!)
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare(exchange: "CursosEstudiantesExchange", type: "fanout", durable: true);
        _channel.QueueDeclare(queue: "CursosQueue", durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind(queue: "CursosQueue", exchange: "CursosEstudiantesExchange", routingKey: "");

        _eventTypeMappings = new Dictionary<string, Type>
        {
            { nameof(MatriculaCreatedIntegrationEvent), typeof(MatriculaCreatedIntegrationEvent) },
            { nameof(MatriculaUpdateFailedIntegrationEvent), typeof(MatriculaUpdateFailedIntegrationEvent) }

        };

        _logger.LogInformation("RabbitMQ connection established");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            try
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var eventName = ea.BasicProperties.Type;

                if (_eventTypeMappings.TryGetValue(eventName, out var eventType))
                {
                    var @event = JsonSerializer.Deserialize(message,eventType);
                    if (@event != null)
                    {   
                        using var scope = _serviceProvider.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        await mediator.Publish(@event, stoppingToken);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar el mensaje de RabbitMQ");
            }
        };

        _channel.BasicConsume(queue: "CursosQueue", autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}