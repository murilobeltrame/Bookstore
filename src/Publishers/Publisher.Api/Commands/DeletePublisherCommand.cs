using Bookstore.CQRS.Interfaces;

namespace Publisher.Api.Commands
{
	public sealed record DeletePublisherCommand(int Id) : ICommand { }
}
