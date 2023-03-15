using MediatR;

namespace Bookstore.CQRS.Interfaces
{
    public interface ICommand<TResponse> : IRequest<TResponse> { }

    public interface ICommand : IRequest { }
}
