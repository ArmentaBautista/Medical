using Medical.Domain.Abstractions;
using MediatR;

namespace Medical.Application.Abstractions.CQRS
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
