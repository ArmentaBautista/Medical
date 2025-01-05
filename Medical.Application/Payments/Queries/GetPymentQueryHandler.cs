using Medical.Application.Abstractions.CQRS;
using Medical.Domain.Abstractions;
using Medical.Domain.Pays;

namespace Medical.Application.Payments.Queries;

public class GetPymentQueryHandler:IQueryHandler<GetPaymentQuery,PaymentResponse>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPymentQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Result<PaymentResponse>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var result = await _paymentRepository.GetByIdAsync(request.id,cancellationToken);

        if (result == null)
            return Result.Failure<PaymentResponse>(PaymentErrors.NotFound);

        return new PaymentResponse(result.Id, result.Amount.Value, result.PaymentDate);

    }
}