namespace Bookstore.CQRS.Interfaces
{
    public interface IEntity<T>
    {
        public int Id { get; }

        public T Update(T entity);
    }
}
