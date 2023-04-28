using BookTouristRoutes.Common.Auth;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.Common.Builders;

public static class GlobalBuilder
{
  public static RouteEntity BuildRoute(
    string? name, string? description,
    DateTime? startDate, DateTime? endDate,
    int? seats, int? bookedSeats,
    decimal? price, string? destination) =>
      new ()
      {
        Name = name ?? AppHelper.GenerateRandomName(),
        Description = description ?? AppHelper.GenerateRandomizeCharacters(7),
        StartDate = startDate ?? DateTime.Now,
        EndDate = endDate ?? DateTime.Now.AddDays(3),
        Seats = seats ?? AppHelper.GenerateRandomNumber(10, 100),
        BookedSeats = bookedSeats ?? AppHelper.GenerateRandomNumber(10, 100),
        Price = price ?? AppHelper.GenerateRandomNumber(0, 1000),
        Destination = destination ?? AppHelper.GenerateRandomizeCharacters(10)
      };

  public static User BuildUser(int userId, string email, string hashedPassword, string salt, string name) =>
    new()
    {
      Id = userId,
      Email = email,
      Password = hashedPassword,
      Salt = salt,
      Name = name
    };

  public static UserDto BuildUserDto(int id, string name, string? avatarUrl, DateTime createdAt, DateTime updatedAt, string email) =>
    new()
    {
      Id = id,
      Name = name,
      Avatar = avatarUrl,
      CreatedAt = createdAt,
      UpdatedAt = updatedAt,
      Email = email
    };

  public static RegisterUserDto BuildRegisterUserDto(
    string? name, string? email, string? password, string? avatar) =>
      new()
      {
        Avatar = avatar,
        CreatedAt = DateTime.Now,
        Email = email ?? AppHelper.GenerateRandomEmail(),
        Id = 0,
        Name = name ?? AppHelper.GenerateRandomName(),
        Password = password ?? AppHelper.GenerateRandomPassword(6)
      };

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
