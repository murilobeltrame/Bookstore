using Ardalis.Specification;
using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Books.Queries
{
    public sealed record FetchBookQuery(int? skip, int? take, string? title, string? author)
        : IQuery<IEnumerable<Book>>
    {
        public Specification<Book> ToSpecification() =>
            new FetchAllBooksPaginatedSpecification(skip, take, title, author);
    }

    public sealed class FetchAllBooksPaginatedSpecification : Specification<Book>
    {
        public FetchAllBooksPaginatedSpecification(int? skip, int? take, string? title, string? author)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                if (title.StartsWith('*') && title.EndsWith('*')) Query.Where(w => w.Title.Contains(title, StringComparison.InvariantCultureIgnoreCase));
                else if (title.EndsWith('*')) Query.Where(w => w.Title.StartsWith(title, StringComparison.InvariantCultureIgnoreCase));
                else if (title.StartsWith('*')) Query.Where(w => w.Title.EndsWith(title, StringComparison.InvariantCultureIgnoreCase));
                else Query.Where(w => w.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase));
            }

            Query
                .Skip(skip.GetValueOrDefault(0))
                .Take(take.GetValueOrDefault(10));
        }
    }
}
