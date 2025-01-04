using Medical.Domain.CommonRecords;

namespace Medical.Application.Abstractions.Communication
{
    public interface IEmailService
    {
        Task SendAsync(Email recipient, string subject, string body);
    }
}
