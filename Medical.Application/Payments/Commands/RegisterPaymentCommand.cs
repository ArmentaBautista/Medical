using Medical.Application.Abstractions.CQRS;

namespace Medical.Application.Payments.Commands;

public record RegisterPaymentCommand(
    Guid AppointmentId,
    decimal Amount,
    DateTime PaymentDate):ICommand<Guid>;