using Medical.Domain.Pays;
using Medical.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace Medical.Infrastructure.Pays;

internal sealed class PaymentRepository(ApplicationDbContext context):RepositoryBase<Payment>(context), IPaymentRepository
{
    public async Task<IReadOnlyList<Payment>> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        return context.Payments.Where(payment => payment.AppointmentId == appointmentId).ToList();
    }

    public Task<IReadOnlyList<Payment>?> GetByPatientIdAsync(Guid patientId, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    
}