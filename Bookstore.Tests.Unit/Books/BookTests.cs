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
			var author = "b";
			var book = new Book(title, author);
			book.Title.Should().BeEquivalentTo(title);
			book.AuthorName.Should().BeEquivalentTo(author);
		}
	}
}
