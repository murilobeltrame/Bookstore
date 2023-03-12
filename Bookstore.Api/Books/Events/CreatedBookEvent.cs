using System;
using Bookstore.Api.Authors;

namespace Bookstore.Api.Books.Events
{
    public class CreatedBookEvent
    {
        public string Title { get; set; } = string.Empty;
        public IEnumerable<string>? AuthorNames { get; set; }
        public string Publisher { get; private set; } = string.Empty;

        public static CreatedBookEvent FromEntity(Book book) => new CreatedBookEvent
        {
            AuthorNames = book.Authors.Select(s => s.Name),
            Publisher = book.Publisher,
            Title = book.Title
        };
    }
}

