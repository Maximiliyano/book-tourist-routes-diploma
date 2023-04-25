using BookTouristRoutes.Tests.Common.Extensions;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.User;

public class LoginUserTest
{
  private readonly AuthHelper _authHelper;
  private readonly UserHelper _userHelper;

  public LoginUserTest()
  {
    _authHelper = new AuthHelper();
    _userHelper = new UserHelper();
  }

  [TestCase("user@example.com", "password123")]
  [TestCase("", "password123")]
  [TestCase("user@example.com", "")]
  [TestCase("", "")]
  [Test]
  public async Task LoginNotExistingUser_ReturnBadRequest(string email, string password)
  {
    // Act
    var response = await _authHelper.Login(email, password);

    // Assert
    using (new AssertionScope())
    {
      response.Should().BeNull();
    }
  }

  [Test]
  public async Task LoginExistingUser_ReturnSuccess()
  {
    // Arrange
    var user = await _userHelper.Create();

    // Act
    var response = await _authHelper.Login(user.Email, user.Password);

    await _userHelper.Delete(user.Id);

    // Assert
    using (new AssertionScope())
    {
      response.Should().NotBeNull();

      response.User.Should().BeEquivalentTo(user, o =>
        o.Excluding(x =>
            x.Id,
            x => x.Password));
    }
  }
}
