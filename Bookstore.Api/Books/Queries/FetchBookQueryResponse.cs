using System;
namespace Bookstore.Api.Books.Queries
{
    public class FetchBookQueryResponse
    {
        public IEnumerable<Author>? Authors { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;

        public static FetchBookQueryResponse FromEntity(Book book) => new FetchBookQueryResponse
        {
            Authors = book.Authors,
            Publisher = book.Publisher,
            Title = book.Title
        };
    }
}

