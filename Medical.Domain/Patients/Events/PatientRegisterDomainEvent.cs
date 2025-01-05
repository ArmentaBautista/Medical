using Medical.Domain.Abstractions;

namespace Medical.Domain.Patients.Events;

public sealed record PatientRegisterDomainEvent(Guid PatineId):IDomainEvent;