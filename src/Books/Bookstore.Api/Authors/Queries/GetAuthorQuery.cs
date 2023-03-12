using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Authors.Queries
{
	public sealed record GetAuthorQuery(int Id) : IQuery<Author> { }
}
