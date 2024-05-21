using MediatR;

namespace HomeHub.Application.Abstraction.CQRS.Query;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}