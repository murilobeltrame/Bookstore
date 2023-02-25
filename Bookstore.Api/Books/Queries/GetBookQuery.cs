using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Books.Queries
{
    public sealed record GetBookQuery(int Id) : IQuery<Book> { }
}
