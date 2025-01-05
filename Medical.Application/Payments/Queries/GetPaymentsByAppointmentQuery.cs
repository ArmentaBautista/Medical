using Medical.Application.Abstractions.CQRS;

namespace Medical.Application.Payments.Queries;

public record GetPaymentsByAppointmentQuery(
    Guid AppointmentId):IQuery<IReadOnlyList<PaymentResponse>>;