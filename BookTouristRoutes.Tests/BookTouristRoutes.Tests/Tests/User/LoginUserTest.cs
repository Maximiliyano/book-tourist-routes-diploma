using System.Net;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Tests.Common.ApiEndpoints;
using BookTouristRoutes.Tests.Common.Extensions;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.User;

public class LoginUserTest
{
  private readonly AuthApi _authApi;
  private readonly UserHelper _userHelper;

  public LoginUserTest()
  {
    _authApi = new AuthApi();
    _userHelper = new UserHelper();
  }

  [TestCase("user@example.com", "password123")]
  [TestCase("", "password123")]
  [TestCase("user@example.com", "")]
  [TestCase("", "")]
  [Test]
  public async Task LoginNotExistingUser_ReturnNotFound(string email, string password)
  {
    // Arrange
    var loginUserDto = BuildLoginUserDto(email, password);

    // Act
    var response = await _authApi.Login(loginUserDto);

    // Assert
    using (new AssertionScope())
    {
      response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
  }

  [Test]
  public async Task LoginExistingUser_ReturnSuccess()
  {
    // Arrange
    var user = await _userHelper.Create();
    var loginUserDto = BuildLoginUserDto(user.Email, user.Password);

    // Act
    var response = await _authApi.Login(loginUserDto);

    await _userHelper.Delete(user.Id);

    // Assert
    using (new AssertionScope())
    {
      response.Should().NotBeNull();

      response.StatusCode.Should().Be(HttpStatusCode.OK);
      response.Data.User.Should().BeEquivalentTo(user, o =>
        o.Excluding(x =>
            x.Id,
            x => x.Password));
    }
  }

  private static LoginUserDto BuildLoginUserDto(string email, string password) =>
    new()
    {
      Email = email,
      Password = password
    };
}
