using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Tests.Common.ApiEndpoints;

namespace BookTouristRoutes.Tests.Helpers;

public class AuthHelper
{
  private readonly AuthApi _authApi;

  public AuthHelper()
  {
    _authApi = new AuthApi();
  }

  public async Task<AuthUserDto?> Login(string email, string password)
  {
    var loginUserDto = BuildLoginUserDto(email, password);
    return (await _authApi.Login(loginUserDto)).Data;
  }

  private static LoginUserDto BuildLoginUserDto(string email, string password) =>
    new()
    {
      Email = email,
      Password = password
    };
}
