using Ardalis.Specification;

namespace Bookstore.CQRS.Interfaces
{
	public interface IRepository<T> where T: class, IEntity<T>
	{
		public Task<T> Create(T entity, CancellationToken cancellationToken = default);

		public Task Update(int id, T entity, CancellationToken cancellationToken = default);

		public Task Delete(int id, CancellationToken cancellationToken = default);

		public Task<T> Get(int id, CancellationToken cancellationToken = default);

        public Task<T> Get(ISpecification<T> specification, CancellationToken cancellationToken = default);

        public Task<TResult> Get<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default);

        public Task<IEnumerable<T>> Query(ISpecification<T> specification, CancellationToken cancellationToken = default);

        public Task<IEnumerable<TResult>> Query<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default);
    }
}
