using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Authors.Commands
{
	public sealed record DeleteAuthorCommand(int Id) : ICommand { }
}
