using Medical.Domain.Abstractions;

namespace Medical.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}
