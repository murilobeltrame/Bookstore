using System.Linq.Expressions;
using Ardalis.Specification;
using Bookstore.Api.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Books.Queries
{
    public sealed record FetchBookQuery(int? skip, int? take, string? title, string? author)
        : IQuery<IEnumerable<FetchBookQueryResponse>>
    {
        public Specification<Book, FetchBookQueryResponse> ToSpecification() =>
            new FetchAllBooksPaginatedSpecification(skip, take, title, author);
    }

    public sealed class FetchAllBooksPaginatedSpecification : Specification<Book, FetchBookQueryResponse>
    {
        public FetchAllBooksPaginatedSpecification(int? skip, int? take, string? title, string? author)
        {
            Query.Include(i => i.Authors);

            if (!string.IsNullOrWhiteSpace(title))
                Query.Search(s => s.Title, title.Replace("*", "%"));

            if (!string.IsNullOrWhiteSpace(author))
            {
                var cleanAuthor = author.Replace("*", string.Empty);
                if (author.StartsWith("*") && author.EndsWith("*")) Query.Where(s => s.Authors.Any(w => w.Name.Contains(cleanAuthor, StringComparison.InvariantCultureIgnoreCase)));
                else if (author.StartsWith("*")) Query.Where(s => s.Authors.Any(w => w.Name.EndsWith(cleanAuthor, StringComparison.InvariantCultureIgnoreCase)));
                else if (author.EndsWith("*")) Query.Where(s => s.Authors.Any(w => w.Name.StartsWith(cleanAuthor, StringComparison.InvariantCultureIgnoreCase)));
                else Query.Where(s => s.Authors.Any(w => w.Name.Equals(cleanAuthor, StringComparison.InvariantCultureIgnoreCase)));
            }

            Query
                .Skip(skip.GetValueOrDefault(0))
                .Take(take.GetValueOrDefault(10));

            Query.Select(book => FetchBookQueryResponse.FromEntity(book));
        }
    }
}
