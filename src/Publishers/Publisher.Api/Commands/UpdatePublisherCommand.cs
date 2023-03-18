using Bookstore.CQRS.Interfaces;

namespace Publisher.Api.Commands
{
    public sealed record UpdatePublisherCommand(
        int Id,
        string Name,
        string OriginCountry,
        string HeadQuartersLocation) : ICommand
    {
        internal Publisher ToEntity() => new(Name, OriginCountry, HeadQuartersLocation);
    }
}
