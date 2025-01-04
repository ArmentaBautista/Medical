using Medical.Domain.Pays;
using Medical.Infrastructure.Shared;

namespace Medical.Infrastructure.Pays;

internal sealed class PaymentRepository(ApplicationDbContext context):RepositoryBase<Payment>(context), IPaymentRepository
{
    public Task<Payment?> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Payment>?> GetByPatientIdAsync(Guid patientId, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    
}