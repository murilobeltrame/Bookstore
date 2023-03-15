using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Bookstore.Common.Exceptions;
using Bookstore.CQRS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.CQRS
{
    public class Repository<T> : IRepository<T> where T : class, Interfaces.IEntity<T>
    {
        private readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

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
            var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
            if (entity == null) throw new NotFoundException();
            return entity;
        }

        public async Task<T> Get(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<T>().AsNoTracking();
            query = SpecificationEvaluator.Default.GetQuery(query, specification);
            var entity = await query.FirstOrDefaultAsync(cancellationToken);
            if (entity == null) throw new NotFoundException();
            return entity;
        }

        public async Task<TResult> Get<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<T>().AsNoTracking();
            var projectedQuery = SpecificationEvaluator.Default.GetQuery(query, specification);
            var entity = await projectedQuery.FirstOrDefaultAsync(cancellationToken);
            if (entity == null) throw new NotFoundException();
            return entity;
        }

        public async Task<IEnumerable<T>> Query(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<T>().AsNoTracking();
            query = SpecificationEvaluator.Default.GetQuery(query, specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> Query<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<T>().AsNoTracking();
            var projectedQuery = SpecificationEvaluator.Default.GetQuery(query, specification);
            return await projectedQuery.ToListAsync(cancellationToken);
        }

        public async Task Update(int id, T entity, CancellationToken cancellationToken = default)
        {
            var toUpdateEntity = entity;
            if (toUpdateEntity.Id < 1)
                toUpdateEntity = (await Get(id, cancellationToken)).Update(entity);
            _context.Set<T>().Update(toUpdateEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
