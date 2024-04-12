using CodigoTransitoReader.Application.Abstractions.Clock;

namespace CodigoTransitoReader.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow { get; } = DateTime.UtcNow;
}