using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Books.Commands
{
    public sealed record CreateBookCommand(string Title, string AuthorName) :
        ICommand<CreateBookCommandResponse>
    {
        public Book ToEntity() => new(Title, AuthorName);
    }
}
