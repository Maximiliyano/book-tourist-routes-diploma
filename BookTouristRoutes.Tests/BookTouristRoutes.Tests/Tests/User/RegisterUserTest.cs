using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.User;

public class RegisterUserTest
{
  private readonly UserHelper _userHelper;
  private readonly ImageHelper _imageHelper;

  private RegisterUserDto _registerUserDto;

  public RegisterUserTest()
  {
    _userHelper = new UserHelper();
    _imageHelper = new ImageHelper();
  }

  [SetUp]
  public async Task Init()
  {
    _registerUserDto = await _userHelper.Create();
  }

  [TearDown]
  public async Task CleanUp()
  {
    await _userHelper.Delete(_registerUserDto.Id);
  }

  [TestCase("", "", "", "")]
  [TestCase("DF$%@@^", "", "", "")]
  [TestCase("DF$%@@^", "https:/ifdsfsdfd.com", "", "")]
  [TestCase("DF$%@@^", "https:/ifdsfsdfd.com", "&%*&^($@$#^", "_)!# )_%#$)^_($)_)$)_^")]
  [TestCase("", "https:/ifdsfsdfd.com", "&%*&^($@$#^", "_)!# )_%#$)^_($)_)$)_^")]
  [TestCase("", "", "&%*&^($@$#^", "_)!# )_%#$)^_($)_)$)_^")]
  [TestCase("", "", "", "_)!# )_%#$)^_($)_)$)_^")]
  [Test]
  public async Task RegisterUser_ReturnBadRequest(string name, string avatar, string email, string password)
  {
    // Act
    var user = await _userHelper.Create(name, avatar, email, password);

    // Assert
    using (new AssertionScope())
    {
      user.Should().BeNull();
    }
  }

  [Test]
  public async Task RegisterExistingUser_UseTheSameEmail_ReturnBadRequest()
  {
    // Act
    var user = await _userHelper.Create(email: _registerUserDto.Email);

    // Assert
    using (new AssertionScope())
    {
      user.Should().BeNull();
    }

    if (user is not null)
    {
      await _userHelper.Delete(user.Id);
    }
  }

  [Test]
  public async Task RegisterNewUser_CompareDataWithExistings_ReturnDifferentUser()
  {
    // Act
    var user = await _userHelper.Create();

    if (user is not null)
    {
      await _userHelper.Delete(user.Id);
    }

    // Assert
    using (new AssertionScope())
    {
      _registerUserDto.Should().NotBeEquivalentTo(user);
    }
  }

  [Test]
  public async Task RegisterNewUser_ReturnNewRequest()
  {
    // Act
    var user = await _userHelper.Create();

    if (user is not null)
    {
      await _userHelper.Delete(user.Id);
    }

    // Assert
    using (new AssertionScope())
    {
      user.Should().NotBeNull();
    }
  }

  [Test]
  public async Task RegisterUserWithAvatarUrl_ReturnNewImageAndUser()
  {
    // Arrange
    var image = new Image();

    // Act
    var user = await _userHelper.Create(avatar: AppHelper.GenerateRandomUrl());

    if (user?.Avatar is not null)
    {
      image = await _imageHelper.Get(user.Avatar);
      await _userHelper.Delete(user.Id);
    }

    // Assert
    using (new AssertionScope())
    {
      user.Should().NotBeNull();

      image?.URL.Should().Be(user?.Avatar);
    }
  }
}
