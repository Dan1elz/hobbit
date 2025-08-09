using System.Linq.Expressions;
using Hobbit.src.Infrastructure;
using Hobbit.src.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Hobbit.src.Repositories.Base;
public class BaseRepository<TEntity>(ApplicationDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context = context;
    protected readonly DbSet<TEntity> DbSeet = context.Set<TEntity>();

    public async Task CreateAsync(TEntity entity, CancellationToken ct)
    {
        await _context.Set<TEntity>().AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(TEntity entity, CancellationToken ct)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken ct)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync(ct);
    }
    
    public async Task<List<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct)
    {
        return await _context.Set<TEntity>().Where(expression).ToListAsync(ct);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(expression, ct);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Set<TEntity>().FindAsync(id, ct);
    }

    
}
