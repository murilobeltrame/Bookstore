using Bookstore.Api;
using Bookstore.Api.Books;
using Bookstore.Api.Shared;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Tests.Unit.Shared
{
    public class RepositoryTests
	{
		private ApplicationContext InMemoryContext(string dbName)
		{
            var context = new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(dbName)
				.EnableSensitiveDataLogging()
                .Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
			return context;
        }

		[Fact]
		public async Task CreateBookShouldCreateARecord()
		{
			var repository = new Repository<Book>(InMemoryContext("CreateEntityRepositoryTest"));

			var book = new Book("a", "b");
            var createdBook = await repository.Create(book);

            createdBook.Should().BeEquivalentTo(book);
			createdBook.Id.Should().BeGreaterThan(0);
		}

		[Fact]
		public void UpdateBookFromInstanceShouldBeUpdated()
		{
			var book = new Book("a", "b");
			var context = InMemoryContext("UpdateEntityRepositoryTest");
			context.Books.Add(book);
			context.SaveChanges();

			var bookToUpdate = new Book("c", "d");
            var repository = new Repository<Book>(context);

			repository.Update(book.Id, bookToUpdate).ContinueWith(result =>
			{
				var updatedBook = context.Books.AsNoTracking().First(w => w.Id == book.Id);
				updatedBook.Title.Should().Be(bookToUpdate.Title);
				updatedBook.AuthorName.Should().Be(bookToUpdate.AuthorName);
			});
        }

		[Fact]
		public void UpdateBookFromEntityShouldBeUpdated()
		{
            var book = new Book("a", "b");
            var context = InMemoryContext("UpdateEntityRepositoryTest");
            context.Books.Add(book);
            context.SaveChanges();

            var bookToUpdate = book.Update(new Book("abc", "def"));
            var repository = new Repository<Book>(context);

            repository.Update(book.Id, bookToUpdate).ContinueWith(result =>
            {
                var updatedBook = context.Books.AsNoTracking().First(w => w.Id == book.Id);
                updatedBook.Title.Should().Be(bookToUpdate.Title);
                updatedBook.AuthorName.Should().Be(bookToUpdate.AuthorName);
            });
        }

		[Fact]
		public void DeleteBookShouldRemoveFromRepository()
		{
			var book = new Book("a", "b");
			var context = InMemoryContext("DeleteEntityRepositoryTest");
			context.Books.Add(book);
			context.SaveChanges();

			var repository = new Repository<Book>(context);
			repository.Delete(book.Id).ContinueWith(result =>
			{
                var books = context.Books.AsNoTracking().ToList();
                books.Should().NotContain(b => b.Id == book.Id);
            });
		}
	}
}
