using Cursos.Api.Middleware;

namespace Cursos.Api.Extensions;

public static class ApplicationBuilderExtensions
{
      public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}