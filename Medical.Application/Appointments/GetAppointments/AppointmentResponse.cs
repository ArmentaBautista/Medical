namespace Medical.Application.Appointments.GetAppointments
{
    public sealed class AppointmentResponse
    {
        public Guid Id { get; init; }
        public Guid DoctorId { get; init; }
        public string DoctorName { get; init; } = default!;
        public Guid PatientId { get; init; }
        public string PatientName { get; init; } = default!;
        public DateTime AppointmentDate { get; init; }
        public decimal PriceAmount { get; init; }
        public decimal TotalPriceAmount { get; init; }
        public string Status { get; init; } = default!;
        public DateTime CreatedOnUtc { get; init; }
    }
}
