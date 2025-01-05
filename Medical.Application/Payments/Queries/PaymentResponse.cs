namespace Medical.Application.Payments.Queries;

public sealed record PaymentResponse(
    Guid Id,
    decimal Amount,
    DateTime PaymentDate);