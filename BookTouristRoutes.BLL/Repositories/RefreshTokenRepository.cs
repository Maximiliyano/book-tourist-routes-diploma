using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.DAL.Context;

namespace BookTouristRoutes.BLL.Repositories;

public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
{
  private readonly BookTouristRoutesContext _context;

  public RefreshTokenRepository(BookTouristRoutesContext context) : base(context)
  {
    _context = context;
  }

  public async Task RemoveTokenAsync(RefreshToken refreshToken) =>
    _context.RefreshTokens.Remove(refreshToken);
}
