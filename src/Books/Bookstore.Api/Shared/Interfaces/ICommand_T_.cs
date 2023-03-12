using MediatR;

namespace Bookstore.Api.Shared.Interfaces
{
    public interface ICommand<TResponse> : IRequest<TResponse> { }

    public interface ICommand : IRequest { }
}
