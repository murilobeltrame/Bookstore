using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Books
{
    public sealed class Book : IEntity<Book>
    {
        public Book(string title, string publisher, IEnumerable<Author> authors)
            => (Title, Publisher, Authors) = (title, publisher, authors);

#pragma warning disable CS8618 // Required by EF.
        private Book() { }
#pragma warning restore CS8618 // Required by EF.

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Publisher { get; private set; }
        public IEnumerable<Author> Authors { get; private set; }

        public Book Update(Book book)
        {
            Title = book.Title;
            Publisher = book.Publisher;
            Authors = book.Authors;
            return this;
        }
    }

    public sealed class Author
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Author(string name) => Name = name;
    }
}
