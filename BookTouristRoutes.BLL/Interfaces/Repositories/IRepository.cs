using System.Linq.Expressions;

namespace BookTouristRoutes.BLL.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
  Task AddAsync(TEntity entity);
  Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression);
  Task<IEnumerable<TEntity>> GetAllAsync();
  Task<TEntity?> GetByIdAsync(int id);
  Task RemoveAsync(TEntity entity);
  Task SaveChangesAsync();
  Task UpdateAsync(TEntity entity);
}
