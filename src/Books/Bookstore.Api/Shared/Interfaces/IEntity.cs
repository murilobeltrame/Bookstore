namespace Bookstore.Api.Shared.Interfaces
{
    public interface IEntity<T>
    {
        public int Id { get; }

        public T Update(T entity);
    }
}
