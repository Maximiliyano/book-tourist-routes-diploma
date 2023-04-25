using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints.Base;
using BookTouristRoutes.Tests.Common.StringFormats;
using RestSharp;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints;

public class UserApi : BaseApi
{
  public UserApi() : base("api/user")
  {
  }

  public async Task<RestResponse<User?>> GetById(int userId)
  {
    var response = CreateGetRequest(string.Format(UserApiStringFormat.GetById, userId));
    return await ExecuteRequest<User?>(response);
  }

  public async Task<RestResponse<User?>> GetByName(string userEmail)
  {
    var response = CreateGetRequest(UserApiStringFormat.GetByName);

    response.AddQueryParameter(nameof(userEmail), userEmail);

    return await ExecuteRequest<User?>(response);
  }

  public async Task<RestResponse<User>> ChangePassword(int userId, string newPassword)
  {
    var response = CreatePutRequest(string.Format(UserApiStringFormat.ChangePassword, userId));

    response.AddQueryParameter(nameof(newPassword), newPassword);

    return await ExecuteRequest<User>(response);
  }

  public async Task<RestResponse<User>> Update(UserDto user)
  {
    var response = CreatePutRequest(string.Empty, user);
    return await ExecuteRequest<User>(response);
  }

  public async Task<RestResponse<IEnumerable<User>>> GetAll()
  {
    var response = CreateGetRequest(UserApiStringFormat.GetAll);
    return await ExecuteRequest<IEnumerable<User>>(response);
  }

  public async Task<RestResponse> Delete(int userId)
  {
    var response = CreateDeleteRequest(string.Format(UserApiStringFormat.Remove, userId));
    return await ExecuteRequest<RestResponse>(response);
  }
}
