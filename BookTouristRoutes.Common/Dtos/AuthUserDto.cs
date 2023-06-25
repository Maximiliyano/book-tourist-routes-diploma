using BookTouristRoutes.Common.Auth;

namespace BookTouristRoutes.Common.Dtos;

public sealed class AuthUserDto
{
  public UserDto User { get; set; }

  public AccessTokenDto Token { get; set; }
}
