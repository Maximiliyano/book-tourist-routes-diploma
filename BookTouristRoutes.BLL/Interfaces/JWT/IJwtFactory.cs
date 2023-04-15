using BookTouristRoutes.Common.Auth;

namespace BookTouristRoutes.BLL.Interfaces.JWT;

public interface IJwtFactory
{
  Task<AccessToken> GenerateAccessToken(int userId, string name, string email);
  string GenerateRefreshToken();
  int GetUserIdFromToken(string accessToken, string signingKey);
}
