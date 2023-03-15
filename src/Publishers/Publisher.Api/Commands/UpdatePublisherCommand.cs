using Bookstore.CQRS.Interfaces;

namespace Publisher.Api.Commands
{
    public sealed record UpdatePublisherCommand(int Id, string Name) : ICommand
    {
        internal Publisher ToEntity() => new(Name);
    }
}
