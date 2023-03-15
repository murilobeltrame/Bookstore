using Bookstore.CQRS.Interfaces;

namespace Bookstore.Api.Authors.Queries
{
	public sealed record GetAuthorQuery(int Id) : IQuery<Author> { }
}
