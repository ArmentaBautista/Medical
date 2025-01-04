using Medical.Domain.Abstractions;

namespace Medical.Domain.Appointments.Events
{
    public sealed record AppointmentCancelledDomainEvent(Guid AppointmentGuid) : IDomainEvent;
}
