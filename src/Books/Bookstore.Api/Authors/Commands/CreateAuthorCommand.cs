using Bookstore.CQRS.Interfaces;

namespace Bookstore.Api.Authors.Commands
{
	public sealed record CreateAuthorCommand(string Name) : ICommand<Author>
	{
		public Author ToEntity() => new(Name);
	}
}
