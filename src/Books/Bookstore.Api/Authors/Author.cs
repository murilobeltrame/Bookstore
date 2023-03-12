using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Authors
{
    public sealed class Author: IEntity<Author>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Author(string name) => Name = name;

        public Author Update(Author author)
        {
            Name = author.Name;
            return this;
        }
    }
}
