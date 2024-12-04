using Usuarios.Application.Abstractions.Time;

namespace Usuarios.Infrastructure.Abstractions.Time;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.Now;
}