using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.BLL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
  private readonly BookTouristRoutesContext _context;

  public UserRepository(BookTouristRoutesContext context) : base(context)
  {
    _context = context;
  }

  public async Task<IEnumerable<User>> GetAllAsync() =>
    await _context.Users
      .AsNoTracking()
      .Include(x => x.Avatar)
      .ToListAsync();

  public async Task<User?> GetByIdAsync(int userId) =>
    await _context.Users
      .AsNoTracking()
      .Include(u => u.Avatar)
      .FirstOrDefaultAsync(x => x.Id == userId);

  public async Task<User?> GetByEmailAsync(string userEmail) =>
    await _context.Users
      .AsNoTracking()
      .Include(u => u.Avatar)
      .FirstOrDefaultAsync(x => x.Email == userEmail);
}
