using Medical.Domain.Abstractions;

namespace Medical.Domain.Appointments.Events
{
    public sealed record AppointmentReservedDomainEvent(Guid AppointmentId) : IDomainEvent;
}
