using Medical.Domain.Abstractions;
using MediatR;

namespace Medical.Application.Abstractions.CQRS
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {

    }
}
