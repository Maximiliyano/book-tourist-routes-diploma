using System.Text.Json.Serialization;
using BookTouristRoutes.Common.Auth;

namespace BookTouristRoutes.Common.Dtos;

public class AuthUserDto
{
  public UserDto User { get; set; }

  [JsonIgnore]
  public AccessTokenDto Token { get; set; }
}
