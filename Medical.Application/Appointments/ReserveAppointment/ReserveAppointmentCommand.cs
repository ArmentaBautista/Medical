using Medical.Application.Abstractions.CQRS;

namespace Medical.Application.Appointments.ReserveAppointment
{
    public record RegisterDoctorCommand(
        Guid DoctorId,
        Guid PatientId,
        DateTime AppointmentDate,
        decimal Price) : ICommand<Guid>;
}
