namespace Medical.Contracts.Payments;

public record RegisterPaymentRequest(
    Guid AppointmentId,
    decimal Amount,
    DateTime PaymentDate);