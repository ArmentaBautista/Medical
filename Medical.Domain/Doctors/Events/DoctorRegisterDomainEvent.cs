using Medical.Domain.Abstractions;

namespace Medical.Domain.Doctors.Events
{
    public sealed record DoctorRegisterDomainEvent(Guid DoctorId) : IDomainEvent;
}
