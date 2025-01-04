using Medical.Domain.Abstractions;
using MediatR;

namespace Medical.Application.Abstractions.CQRS
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {

    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {

    }

    public interface IBaseCommand
    {

    }
}
