using Bookstore.CQRS.Interfaces;

namespace Bookstore.Api.Books.Commands
{
    public sealed record DeleteBookCommand(int Id) : ICommand { }
}
