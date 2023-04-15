using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Repositories;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
  Task RemoveTokenAsync(RefreshToken refreshToken);
}
