using System;
namespace Bookstore.Api.Books.Events
{
    public class CreatedBookEvent
    {
        public string Title { get; set; } = string.Empty;
        public IEnumerable<Author>? Authors { get; set; }
        public string Publisher { get; private set; } = string.Empty;

        public static CreatedBookEvent FromEntity(Book book) => new CreatedBookEvent
        {
            Authors = book.Authors,
            Publisher = book.Publisher,
            Title = book.Title
        };
    }
}

