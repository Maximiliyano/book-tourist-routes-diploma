using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Tests.Common.ApiEndpoints.Base;
using RestSharp;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints;

public class RegisterApi : BaseApi
{
  public RegisterApi() : base("api/register")
  {
  }

  public async Task<RestResponse<AuthUserDto>> Create(RegisterUserDto registerUserDto)
  {
    var request = CreatePostRequest("new", registerUserDto);
    return await ExecuteRequest<AuthUserDto>(request);
  }
}
