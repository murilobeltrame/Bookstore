using Bookstore.Api.Authors;
using Bookstore.CQRS.Interfaces;

namespace Bookstore.Api.Books.Commands
{
    public sealed record CreateBookCommand(string Title, string Publisher, IEnumerable<Author> Authors) :
        ICommand<CreateBookCommandResponse>
    {
        public Book ToEntity(IEnumerable<Author>? existingAuthors)
        {
            var authors = existingAuthors?.Any() ?? false ?
                Authors.Select(author => existingAuthors.FirstOrDefault(w => w.Name == author.Name) ?? author) :
                Authors;
            return new Book(Title, Publisher, authors);
        }
    }
}
