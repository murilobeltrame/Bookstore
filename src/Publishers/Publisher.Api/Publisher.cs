using Bookstore.CQRS.Interfaces;

namespace Publisher.Api
{
	public sealed class Publisher:IEntity<Publisher>
	{
		public Publisher(string name) => Name = name;

        public string Name { get; private set; }

        public int Id { get; private set; }

        public Publisher Update(Publisher publisher)
        {
            Name = publisher.Name;
            return this;
        }
    }
}
