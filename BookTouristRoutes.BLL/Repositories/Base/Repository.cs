using System.Linq.Expressions;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.BLL.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
  private readonly BookTouristRoutesContext _context;

  public Repository(BookTouristRoutesContext context)
  {
    _context = context;
  }

  public virtual async Task AddAsync(TEntity entity)
  {
    await _context.Set<TEntity>().AddAsync(entity);
    await SaveChangesAsync();
  }

  public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
  {
    return await _context.Set<TEntity>().ToListAsync();
  }

  public virtual async Task<TEntity?> GetByIdAsync(int id)
  {
    return await _context.Set<TEntity>().FindAsync(id);
  }

  public virtual async Task RemoveAsync(TEntity entity)
  {
    _context.Set<TEntity>().Remove(entity);
    await SaveChangesAsync();
  }

  public virtual async Task UpdateAsync(TEntity entity)
  {
    _context.Entry(entity).State = EntityState.Modified;
    _context.Set<TEntity>().Update(entity);
    await SaveChangesAsync();
    _context.Entry(entity).State = EntityState.Detached;
  }

  public async Task SaveChangesAsync()
  {
    await _context.SaveChangesAsync();
  }

  public virtual async Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> expression)
  {
    return await _context.Set<TEntity>().Where(expression).AsQueryable().FirstAsync();
  }

  public virtual async Task<TEntity?> FindFirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
  {
    return await _context.Set<TEntity>().Where(expression).AsQueryable().FirstOrDefaultAsync();
  }
}
