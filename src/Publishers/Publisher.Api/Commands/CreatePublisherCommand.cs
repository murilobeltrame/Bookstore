using Bookstore.CQRS.Interfaces;

namespace Publisher.Api.Commands
{
    public sealed record CreatePublisherCommand(string Name) : ICommand<Publisher>
    {
        internal Publisher ToEntity() => new(Name);
    }
}
