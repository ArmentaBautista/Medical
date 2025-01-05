using Medical.Domain.Abstractions;

namespace Medical.Domain.Pays.Events;

public sealed record PaymentRegisteredDomainEvent(Guid id):IDomainEvent;