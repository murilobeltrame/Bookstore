using Bookstore.Api.Authors;
using Bookstore.Api.Books;
using FluentAssertions;

namespace Bookstore.Tests.Unit.Books
{
    public class BookTests
    {
        [Fact]
        public void ShouldBeInstantiated()
        {
            var title = "a";
            var publisher = "c";
            var author = new Author("b");
            var book = new Book(title, publisher, new List<Author> { author });
            book.Title.Should().BeEquivalentTo(title);
            book.Publisher.Should().BeEquivalentTo(publisher);
            book.Authors.Should().Contain(author);
        }
    }
}
