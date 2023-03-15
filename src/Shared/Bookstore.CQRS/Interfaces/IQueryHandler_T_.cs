using MediatR;

namespace Bookstore.CQRS.Interfaces
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
		where TQuery : IQuery<TResponse>
	{ }
}
