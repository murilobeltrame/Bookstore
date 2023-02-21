using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Bookstore.Api.Shared.Exceptions;
using Bookstore.Api.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api.Shared
{
    public class Repository<T>: IRepository<T> where T : class, IEntity
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context) => _context = context;

        public async Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var entity = await Get(id, cancellationToken);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> Get(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
            if (entity == null) throw new NotFoundException();
            return entity;
        }

        public async Task<IEnumerable<T>> Query(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<T>().AsQueryable();
            query = SpecificationEvaluator.Default.GetQuery(query, specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task Update(T entity, CancellationToken cancellationToken = default)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
