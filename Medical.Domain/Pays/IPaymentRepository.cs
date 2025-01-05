namespace Medical.Domain.Pays;

public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Payment>> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken);
    Task<IReadOnlyList<Payment>?> GetByPatientIdAsync(Guid patientId, CancellationToken cancellation);

    void Add(Payment  payment);
}