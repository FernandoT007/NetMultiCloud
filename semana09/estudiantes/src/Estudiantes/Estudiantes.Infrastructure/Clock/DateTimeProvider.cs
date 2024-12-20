using Estudiantes.Application.Abstractions.Clock;

namespace Estudiantes.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}