using BookTouristRoutes.Common.Auth;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.Common.Builders;

public static class GlobalBuilder
{
  public static AuthUserDto BuildAuthUserDto(UserDto userDto, AccessTokenDto accessTokenDto) =>
    new()
    {
      User = userDto,
      Token = accessTokenDto
    };

  public static RefreshToken BuildRefreshToken(string token, int userId) =>
    new()
    {
      Token = token,
      UserId = userId
    };

  public static AccessTokenDto BuildAccessTokenDto(AccessToken accessToken, string token) =>
    new (accessToken, token);
}
