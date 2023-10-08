using System.Linq.Expressions;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.BLL.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
  private readonly BookTouristRoutesContext _context;

  protected Repository(BookTouristRoutesContext context)
  {
    _context = context;
  }

  public virtual async Task CreateAsync(TEntity entity)
  {
    await _context.Set<TEntity>().AddAsync(entity);
    await SaveChangesAsync();
  }

  public virtual async Task DeleteAsync(TEntity entity)
  {
    _context.Set<TEntity>().Remove(entity);
    await SaveChangesAsync();
  }

  public virtual async Task UpdateAsync(TEntity entity)
  {
    _context.Entry(entity).State = EntityState.Modified;
    _context.Set<TEntity>().Update(entity);
    await _context.SaveChangesAsync();
    _context.Entry(entity).State = EntityState.Detached;
  }

  public async Task SaveChangesAsync()
  {
    await _context.SaveChangesAsync();
  }

  public virtual async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression)
  {
    var response = await _context.Set<TEntity>().Where(expression).AsQueryable().FirstAsync();
    _context.Entry(response).State = EntityState.Detached;

    return response;
  }

  public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
  {
    var response = await _context.Set<TEntity>().Where(expression).AsQueryable().FirstOrDefaultAsync();
    if (response is not null)
      _context.Entry(response).State = EntityState.Detached;

    return response;
  }
}
