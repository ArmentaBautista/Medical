using Medical.Application.Abstractions.Time;

namespace Medical.Infrastructure.Implementations.Time
{
    internal sealed class TimeProvider : ITimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
