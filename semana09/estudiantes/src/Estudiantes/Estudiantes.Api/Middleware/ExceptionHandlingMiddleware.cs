using Microsoft.AspNetCore.Mvc;
using Estudiantes.Application.Exceptions;

namespace Estudiantes.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // si no hay error continua
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrio una excepcion: {Message}", ex.Message);
            var excepcionDetail = GetExceptionDeails(ex); //obtener detalle de exceiciones
            var problemDetail = new ProblemDetails
            {
                Status = excepcionDetail.Status,
                Type = excepcionDetail.Type,
                Title = excepcionDetail.Title,
                Detail = excepcionDetail.Detail,
            };

            if (excepcionDetail.Errors  is not null)
            {
                problemDetail.Extensions["errors"] = excepcionDetail.Errors;
            }

            context.Response.StatusCode = excepcionDetail.Status;

            await context.Response.WriteAsJsonAsync(problemDetail);
        }
    }

    private static ExceptionDetails GetExceptionDeails(Exception exception)
    {
        return exception switch // nueva sintaxis
        {
            ValidationExceptions validationException => new ExceptionDetails(
                StatusCodes.Status400BadRequest,
                "ValidationFailure",
                "Validacion de Error",
                "Han ocurrido uno o mas errores de validacion",
                validationException.Errors
            ),
            _ => new ExceptionDetails(
                  StatusCodes.Status500InternalServerError,
                 "ServerError",
                 "Error de Servidor",
                 "Han ocurrido un inesperado error en la app",
                 null
                )
        };
    }

    internal record ExceptionDetails
    (
        int Status,
        string Type,
        string Title,
        string Detail,
        IEnumerable<object>? Errors
    );

}



