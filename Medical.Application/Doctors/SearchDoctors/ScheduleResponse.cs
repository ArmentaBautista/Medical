namespace FlatFinder.Application.Flats.SearchFlats
{
    public sealed class ScheduleResponse
    {
        public Guid DoctorId { get; set; } = default!;

        public DateTime StartTime { get; set; } = default!;
        public DateTime EndTime { get; set; } = default!;
    }
}
