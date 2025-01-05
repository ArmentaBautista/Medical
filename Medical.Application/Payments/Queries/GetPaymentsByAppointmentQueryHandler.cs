using Medical.Application.Abstractions.CQRS;
using Medical.Domain.Abstractions;
using Medical.Domain.Pays;

namespace Medical.Application.Payments.Queries;

public class GetPaymentsByAppointmentQueryHandler:IQueryHandler<GetPaymentsByAppointmentQuery,IReadOnlyList<PaymentResponse>>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentsByAppointmentQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Result<IReadOnlyList<PaymentResponse>>> Handle(GetPaymentsByAppointmentQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _paymentRepository.GetByAppointmentIdAsync(request.AppointmentId,cancellationToken);

        return result.Select(payment => new PaymentResponse(payment.Id, payment.Amount.Value, payment.PaymentDate)).ToList();
    }
}