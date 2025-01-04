
using Medical.Domain.Abstractions;

namespace Medical.Domain.Appointments.Events
{
    public sealed record AppointmentRejectedDomainEvent(Guid AppointmentId) :IDomainEvent;
}
