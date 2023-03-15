using Bookstore.CQRS.Interfaces;

namespace Bookstore.Api.Authors.Commands
{
	public sealed record UpdateAuthorCommand(int Id, string Name): ICommand
	{
		public Author ToEntity() => new(Name);
	}
}

