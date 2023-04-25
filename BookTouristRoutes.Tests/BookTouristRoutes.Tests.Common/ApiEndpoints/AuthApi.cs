using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Tests.Common.ApiEndpoints.Base;
using RestSharp;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints;

public class AuthApi : BaseApi
{
  public AuthApi() : base("api/authorization")
  {
  }

  public async Task<RestResponse<AuthUserDto>> Login(LoginUserDto model)
  {
    var request = CreatePostRequest("login", model);
    return await ExecuteRequest<AuthUserDto>(request);
  }
}
