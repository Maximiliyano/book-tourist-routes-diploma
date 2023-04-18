using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints.Base;
using RestSharp;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints;

public class UserApi : AppBaseApi
{
  public UserApi() : base("api/user")
  {
  }

  public async Task<RestResponse<User?>> GetById(int userId)
  {
    var response = CreateGetRequest($"details/{userId}");
    return await ExecuteRequest<User?>(response);
  }

  public async Task<RestResponse<User?>> GetByName(string userEmail)
  {
    var response = CreateGetRequest("details");

    response.AddQueryParameter(userEmail, userEmail);

    return await ExecuteRequest<User?>(response);
  }

  public async Task<RestResponse<User>> ChangePassword(int userId, string newPassword)
  {
    var response = CreatePutRequest($"{userId}/change-pass?newPassword={newPassword}");

    return await ExecuteRequest<User>(response);
  }

  public async Task<RestResponse<User>> Update(UserDto user)
  {
    var response = CreatePutRequest(string.Empty, user);
    return await ExecuteRequest<User>(response);
  }

  public async Task<RestResponse<IEnumerable<User>>> GetAll()
  {
    var response = CreateGetRequest("all");
    return await ExecuteRequest<IEnumerable<User>>(response);
  }

  public async Task<RestResponse> Delete(int userId)
  {
    var response = CreateDeleteRequest($"remove/{userId}");
    return await ExecuteRequest<RestResponse>(response);
  }
}
