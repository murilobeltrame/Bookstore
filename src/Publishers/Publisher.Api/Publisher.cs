using Bookstore.CQRS.Interfaces;

namespace Publisher.Api
{
	public sealed class Publisher:IEntity<Publisher>
	{
		public Publisher(string name) => Name = name;

        public string Name { get; private set; }

        public int Id => throw new NotImplementedException();

        public Publisher Update(Publisher publisher)
        {
            this.Name = publisher.Name;
            return this;
        }
    }
}
