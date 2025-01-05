using Medical.Application.Abstractions.CQRS;

namespace Medical.Application.Payments.Queries;

public record GetPaymentQuery(Guid id):IQuery<PaymentResponse>;