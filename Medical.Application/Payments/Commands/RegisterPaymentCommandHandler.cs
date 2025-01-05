using Medical.Application.Abstractions.CQRS;
using Medical.Application.Exceptions;
using Medical.Domain.Abstractions;
using Medical.Domain.Pays;

namespace Medical.Application.Payments.Commands;

public class RegisterPaymentCommandHandler : ICommandHandler<RegisterPaymentCommand, Guid>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterPaymentCommandHandler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterPaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var payment = Payment.Register(request.AppointmentId, request.Amount, request.PaymentDate);

            _paymentRepository.Add(payment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return payment.Id;
        }
        catch (PersistenceConcurrencyException)
        {
            return Result.Failure<Guid>(PaymentErrors.NotFound);
        }
    }
}