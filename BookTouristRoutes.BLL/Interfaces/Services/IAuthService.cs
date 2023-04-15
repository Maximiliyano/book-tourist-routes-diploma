using BookTouristRoutes.Common.Auth;
using BookTouristRoutes.Common.Dtos;

namespace BookTouristRoutes.BLL.Interfaces.Services;

public interface IAuthService
{
  Task<AuthUserDto> Authorize(LoginUserDto credentials);
  Task<AccessTokenDto> GenerateAccessToken(int userId, string userName, string email);
  Task<AccessTokenDto> RefreshToken(RefreshTokenDto dto);
  Task RevokeRefreshToken(string refreshToken, int userId);
}
