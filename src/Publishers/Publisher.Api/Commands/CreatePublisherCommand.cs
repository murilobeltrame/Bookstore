using Bookstore.CQRS.Interfaces;

namespace Publisher.Api.Commands
{
    public sealed record CreatePublisherCommand(
        string Name,
        string OriginCountry,
        string HeadQuartersLocation) : ICommand<Publisher>
    {
        internal Publisher ToEntity() => new(Name, OriginCountry, HeadQuartersLocation);
    }
}
