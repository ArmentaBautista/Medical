using Medical.Application.Abstractions.CQRS;

namespace Medical.Application.Appointments.GetAppointments
{
    public sealed record GetAppointmentQuery(Guid AppointmentId) : IQuery<AppointmentResponse>;
}
