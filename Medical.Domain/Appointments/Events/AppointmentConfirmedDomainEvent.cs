using Medical.Domain.Abstractions;

namespace Medical.Domain.Appointments.Events
{
    public sealed record AppointmentConfirmedDomainEvent(Guid AppointmentId) : IDomainEvent;
}
