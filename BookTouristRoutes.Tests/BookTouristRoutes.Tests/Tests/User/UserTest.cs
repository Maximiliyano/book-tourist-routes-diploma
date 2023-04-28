using BookTouristRoutes.Common.Builders;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Tests.Common.Extensions;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.User;

public class UserTest
{
  private readonly UserHelper _userHelper;

  private RegisterUserDto _user;

  public UserTest()
  {
    _userHelper = new UserHelper();
  }

  [SetUp]
  public async Task SetUp()
  {
    _user = await _userHelper.Create();
  }

  [TearDown]
  public async Task TearDown()
  {
    await _userHelper.Delete(_user.Id);
  }

  [TestCase(true)]
  [TestCase(false)]
  [Test]
  public async Task GetAllUsers_ReturnListWithUsers(bool createUser)
  {
    var user = new RegisterUserDto();

    // Arrange
    if (createUser)
      user = await _userHelper.Create();

    // Act
    var users = await _userHelper.GetAll();

    if (createUser)
      await _userHelper.Delete(user.Id);

    // Assert
    using (new AssertionScope())
    {
      users.Should().NotBeNull();

      if (createUser)
        users.Should().Contain(x => x.Id == user.Id);
    }
  }

  [Test]
  public async Task GetUserById_ReturnUser()
  {
    // Act
    var user = await _userHelper.Get(_user.Id);

    // Assert
    using (new AssertionScope())
    {
      user.Should().BeEquivalentTo(_user, o =>
        o.Excluding(x => x.Password));
    }
  }

  [Test]
  public async Task GetUserByEmail_ReturnUser()
  {
    // Act
    var user = await _userHelper.Get(_user.Email);

    // Assert
    using (new AssertionScope())
    {
      user.Should().BeEquivalentTo(_user, o => o
        .Excluding(x => x.Password));
    }
  }

  [Test]
  public async Task ChangePasswordUser_ReturnNewPassword()
  {
    // Arrange
    var newPassword = AppHelper.GenerateRandomPassword(5);

    // Act
    var userWithOldPassword = await _userHelper.Get(_user.Id);
    var userWithUpdatedPassword = await _userHelper.ChangePassword(_user.Id, newPassword);

    // Assert
    using (new AssertionScope())
    {
      _user.Password.Should().NotBe(newPassword);

      userWithUpdatedPassword.Should().BeEquivalentTo(userWithOldPassword, o => o
        .Excluding(
          x => x.UpdatedAt,
          x => x.Password,
          x => x.Salt));
    }
  }

  [Test]
  public async Task UpdateUserData_ReturnUserWithUpdatedData()
  {
    // Arrange
    var name = AppHelper.GenerateRandomName();

    // Act
    var userWithUpdatedData = await UpdateUserName(name);

    // Assert
    using (new AssertionScope())
    {
      userWithUpdatedData.Should().NotBeEquivalentTo(_user);

      userWithUpdatedData.Name.Should().Be(name);
    }
  }

  private async Task<BookTouristRoutes.Common.Models.User?> UpdateUserName(string newName)
  {
    var userDto = GlobalBuilder.BuildUserDto(_user.Id, newName, _user.Avatar, _user.CreatedAt, _user.UpdatedAt, _user.Email);
    return await _userHelper.Update(userDto);
  }
}
