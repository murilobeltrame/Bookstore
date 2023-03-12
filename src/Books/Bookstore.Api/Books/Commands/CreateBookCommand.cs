using Bookstore.Api.Authors;
using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Books.Commands
{
    public sealed record CreateBookCommand(string Title, string Publisher, IEnumerable<Author> Authors) :
        ICommand<CreateBookCommandResponse>
    {
        public Book ToEntity() => new(Title, Publisher, Authors);
    }
}
