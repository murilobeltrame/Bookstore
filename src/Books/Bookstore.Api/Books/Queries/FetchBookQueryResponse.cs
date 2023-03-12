using System;
using Bookstore.Api.Authors;

namespace Bookstore.Api.Books.Queries
{
    public class FetchBookQueryResponse
    {
        public IEnumerable<string>? AuthorNames { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;

        public static FetchBookQueryResponse FromEntity(Book book) => new FetchBookQueryResponse
        {
            AuthorNames = book.Authors.Select(s => s.Name),
            Publisher = book.Publisher,
            Title = book.Title
        };
    }
}

