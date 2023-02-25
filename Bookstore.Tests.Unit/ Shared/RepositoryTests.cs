using Bookstore.Api;
using Bookstore.Api.Books;
using Bookstore.Api.Shared;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Bookstore.Tests.Unit.Shared
{
    public class RepositoryTests
	{
		//private static Mock<ApplicationContext> MockApplicationContext()
		//{
  //          var mockContext = new Mock<ApplicationContext>();
		//	mockContext.Setup(m => m.Books).ReturnsDbSet(new List<Book> { new("a", "b"), new("c", "d") });
		//	return mockContext;
  //      }

		[Fact]
		public async Task CreateBookShouldCreateARecord()
		{
            var _context = new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>()
				.UseInMemoryDatabase("RepositoryTests")
				.Options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();

			var repository = new Repository<Book>(_context);

			var book = new Book("a", "b");
            var createdBook = await repository.Create(book);

            createdBook.Should().BeEquivalentTo(book);
			createdBook.Id.Should().BeGreaterThan(0);
		}
	}
}
