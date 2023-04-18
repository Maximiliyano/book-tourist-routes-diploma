using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.RegisterApiTests;

public class RegisterUserTest
{
  private readonly UserHelper _userHelper;
  private readonly ImageHelper _imageHelper;

  private RegisterUserDto _registerUserDto;

  private static string email = AppHelper.GenerateRandomName();

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
    var user = new RegisterUserDto();

    // Act
    try
    {
      user = await _userHelper.Create(name, avatar, email, password);
    }
    catch (InvalidOperationException e)
    {
      await _userHelper.Delete(user.Id);

      // Assert
      using (new AssertionScope())
      {
        user.Id.Should().Be(0);
      }
    }
  }

  [Test]
  public async Task RegisterExistingUser_UseTheSameEmail_ReturnBadRequest()
  {
    var user = new RegisterUserDto();

    // Act
    try
    {
      user = await _userHelper.Create(email: _registerUserDto.Email);
    }
    catch (InvalidOperationException e)
    {
      await _userHelper.Delete(user.Id);

      // Assert
      using (new AssertionScope())
      {
        user.Id.Should().Be(0);
      }
    }
  }

  [Test]
  public async Task RegisterNewUser_CompareDataWithExistings_ReturnDifferentUser()
  {
    // Act
    var user = await _userHelper.Create();

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

    // Assert
    using (new AssertionScope())
    {
      user.Id.Should().NotBe(0);
    }
  }

  [Test]
  public async Task RegisterUserWithAvatarUrl_ReturnNewImageAndUser()
  {
    // Act
    var user = await _userHelper.Create(avatar: AppHelper.GenerateRandomUrl());
    var image = await _imageHelper.Get(user.Avatar);

    await _userHelper.Delete(user.Id);

    // Assert
    using (new AssertionScope())
    {
      user.Id.Should().NotBe(0);
      image.URL.Should().Be(user.Avatar);
    }
  }
}
