using Bookstore.CQRS.Interfaces;

namespace Publisher.Api.Queries
{
	public sealed record GetPublisherByIdQuery(int Id) : IQuery<Publisher> { }
}
