using MediatR;

namespace Bookstore.Api.Shared.Interfaces
{
    public interface IQuery<TResponse> : IRequest<TResponse> { }
}
