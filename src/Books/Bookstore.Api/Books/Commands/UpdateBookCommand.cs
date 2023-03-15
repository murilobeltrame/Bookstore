using Bookstore.Api.Authors;
using Bookstore.CQRS.Interfaces;

namespace Bookstore.Api.Books.Commands
{
    public sealed record UpdateBookCommand(int Id, string Title, string Publisher, IEnumerable<Author> Authors) :
        ICommand
    {
        public Book ToEntity() => new(Title, Publisher, Authors);
    }
}
