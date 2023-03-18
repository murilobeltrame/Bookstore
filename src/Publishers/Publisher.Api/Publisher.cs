using Bookstore.CQRS.Interfaces;

namespace Publisher.Api
{
	public sealed class Publisher:IEntity<Publisher>
	{
#pragma warning disable CS8618 // Required by EF.
        private Publisher() { }
#pragma warning restore CS8618 // Required by EF.

        public Publisher(
            string name,
            string originContry,
            string headquartersLocation) =>
            (Name, OriginCountry, HeadquartersLocation) =
            (name, originContry, headquartersLocation);

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string OriginCountry { get; private set; }
        public string HeadquartersLocation { get; private set; }

        public Publisher Update(Publisher publisher)
        {
            Name = publisher.Name;
            OriginCountry = publisher.OriginCountry;
            HeadquartersLocation = publisher.HeadquartersLocation;
            return this;
        }
    }
}
