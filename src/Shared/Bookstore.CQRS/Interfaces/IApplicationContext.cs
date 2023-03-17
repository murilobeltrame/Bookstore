using Microsoft.EntityFrameworkCore;

namespace Bookstore.CQRS.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
