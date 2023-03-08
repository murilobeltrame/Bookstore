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
            if (!string.IsNullOrWhiteSpace(title))
                Query.Search(s => s.Title, title.Replace("*", "%"));

            if (!string.IsNullOrWhiteSpace(author))
                Query.Search(s => s.AuthorName, author.Replace("*", "%"));

            Query
                .Skip(skip.GetValueOrDefault(0))
                .Take(take.GetValueOrDefault(10));

            Query.Select(book => FetchBookQueryResponse.FromEntity(book));
        }
    }
}
