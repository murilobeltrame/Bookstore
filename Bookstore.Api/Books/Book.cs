using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Books
{
    public sealed class Book : IEntity
    {
        public Book(string title, string authorName)
            => (Title, AuthorName) = (title, authorName);

#pragma warning disable CS8618 // Required by EF.
        private Book() { }
#pragma warning restore CS8618 // Required by EF.

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string AuthorName { get; private set; }

        public Book Update(string title, string authorName)
        {
            this.Title = title;
            this.AuthorName = authorName;
            return this;
        }
    }
}
