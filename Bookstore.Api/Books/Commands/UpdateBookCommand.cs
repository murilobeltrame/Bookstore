using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Books.Commands
{
    public sealed record UpdateBookCommand(int Id, string Title, string AuthorName) :
        ICommand
    { }
}
