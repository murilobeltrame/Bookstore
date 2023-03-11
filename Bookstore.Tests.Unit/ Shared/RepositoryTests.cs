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

            var book = new Book("a", "b", new List<Author> { new Author("c") });
            var createdBook = await repository.Create(book);

            createdBook.Should().BeEquivalentTo(book);
            createdBook.Id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void UpdateBookFromInstanceShouldBeUpdated()
        {
            var book = new Book("a", "b", new List<Author> { new Author("c") });
            var context = InMemoryContext("UpdateEntityRepositoryTest");
            context.Books.Add(book);
            context.SaveChanges();

            var bookToUpdate = new Book("d", "e", new List<Author> { new Author("f") });
            var repository = new Repository<Book>(context);

            repository.Update(book.Id, bookToUpdate).ContinueWith(result =>
            {
                var updatedBook = context.Books.AsNoTracking().First(w => w.Id == book.Id);
                updatedBook.Title.Should().Be(bookToUpdate.Title);
                updatedBook.Publisher.Should().Be(bookToUpdate.Publisher);
                updatedBook.Authors.Should().Contain(bookToUpdate.Authors.First());
            });
        }

        [Fact]
        public void UpdateBookFromEntityShouldBeUpdated()
        {
            var book = new Book("a", "b", new List<Author> { new Author("c") });
            var context = InMemoryContext("UpdateEntityRepositoryTest");
            context.Books.Add(book);
            context.SaveChanges();

            var bookToUpdate = book.Update(new Book("abc", "def", new List<Author> { new Author("ghi") }));
            var repository = new Repository<Book>(context);

            repository.Update(book.Id, bookToUpdate).ContinueWith(result =>
            {
                var updatedBook = context.Books.AsNoTracking().First(w => w.Id == book.Id);
                updatedBook.Title.Should().Be(bookToUpdate.Title);
                updatedBook.Publisher.Should().Be(bookToUpdate.Publisher);
                updatedBook.Authors.Should().Contain(bookToUpdate.Authors.First());
            });
        }

        [Fact]
        public void DeleteBookShouldRemoveFromRepository()
        {
            var book = new Book("a", "b", new List<Author> { new Author("c") });
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
