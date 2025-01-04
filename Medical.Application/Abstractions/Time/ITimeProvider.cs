namespace Medical.Application.Abstractions.Time
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
    }
}
