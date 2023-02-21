using Ardalis.Specification;

namespace Bookstore.Api.Shared.Interfaces
{
	public interface IRepository<T> where T: class, IEntity
	{
		public Task<T> Create(T entity, CancellationToken cancellationToken = default);

		public Task Update(T entity, CancellationToken cancellationToken = default);

		public Task Delete(int id, CancellationToken cancellationToken = default);

		public Task<T> Get(int id, CancellationToken cancellationToken = default);

		public Task<IEnumerable<T>> Query(ISpecification<T> specification, CancellationToken cancellationToken = default);
	}
}
