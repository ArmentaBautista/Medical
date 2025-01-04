using Medical.Application.Abstractions.Communication;
using Medical.Domain.Users;

namespace Medical.Infrastructure.Implementations.Communication
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendAsync(Domain.CommonRecords.Email recipient, string subject, string body)
        {
            //here should go the email sending implementation
            return Task.CompletedTask;
        }

    }
}
