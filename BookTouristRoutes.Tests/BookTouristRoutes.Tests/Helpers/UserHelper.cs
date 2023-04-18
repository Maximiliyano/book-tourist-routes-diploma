using BookTouristRoutes.Common.Builders;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints;

namespace BookTouristRoutes.Tests.Helpers;

public class UserHelper
{
  private readonly UserApi _userApi;
  private readonly RegisterApi _registerApi;

  public UserHelper()
  {
    _userApi = new UserApi();
    _registerApi = new RegisterApi();
  }

  public async Task<RegisterUserDto> Create(
    string? name = null,
    string? avatar = null,
    string? email  = null,
    string? password  = null)
  {
    var registerUserDto = GlobalBuilder.BuildRegisterUserDto(name, email, password, avatar);
    var userDto = (await _registerApi.Create(registerUserDto)).Data?.User;

    if (userDto is null)
      throw new InvalidOperationException($"Error creation model: {userDto} is not exist!");

    registerUserDto.Id = userDto.Id;
    return registerUserDto;
  }

  public async Task<IEnumerable<User>?> GetAll() =>
    (await _userApi.GetAll()).Data;

  public async Task<User?> Get(int userId) =>
    (await _userApi.GetById(userId)).Data;

  public async Task<User?> Get(string userName) =>
    (await _userApi.GetByName(userName)).Data;

  public async Task<User?> Update(UserDto userDto) =>
    (await _userApi.Update(userDto)).Data;

  public async Task<User?> ChangePassword(int userId, string newPassword) =>
    (await _userApi.ChangePassword(userId, newPassword)).Data;

  public async Task Delete(int userId) =>
    await _userApi.Delete(userId);
}
