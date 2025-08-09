using System.Linq.Expressions;

namespace Hobbit.src.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<List<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct);
        Task CreateAsync(TEntity entity, CancellationToken ct);
        Task UpdateAsync(TEntity entity, CancellationToken ct);
        Task RemoveAsync(TEntity entity, CancellationToken ct);
    }
}