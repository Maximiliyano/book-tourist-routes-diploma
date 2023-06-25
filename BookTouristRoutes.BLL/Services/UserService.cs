using System.Net;
using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class UserService : BaseService<IUserRepository, User>, IUserService
{
  private readonly ImageService _imageService;

  public UserService(
    IUserRepository userRepository,
    IImageRepository imageRepository,
    IMapper mapper) : base(userRepository, mapper)
  {
    _imageService = new ImageService(imageRepository, mapper);
  }

  public async Task<UserDto> CreateUser(RegisterUserDto registerUser)
  {
    await ValidateUserIsExistByEmail(registerUser.Email);

    if (string.IsNullOrEmpty(registerUser.Email) || string.IsNullOrEmpty(registerUser.Password) || string.IsNullOrEmpty(registerUser.Name))
    {
      throw new CustomException("Required fields is empty!", HttpStatusCode.BadRequest);
    }

    var user = _mapper.Map<User>(registerUser);
    var authData = EncodeUserPassword(registerUser.Password);

    user.Salt = authData.Salt;
    user.Password = authData.Password;

    await Create(user);

    var createdUser = await Get(user.Email);
    return _mapper.Map<UserDto>(createdUser);
  }

  public async Task Delete(int userId)
  {
    var user = await Get(userId);

    if (user is null)
      throw new NotFoundException(nameof(user), userId);

    await Delete(user);
  }

  public async Task<User> ChangePassword(int userId, string newPassword)
  {
    var userEntity = await Get(userId);
    var authData = EncodeUserPassword(newPassword);

    if (SecurityHelper.ValidatePassword(newPassword, userEntity.Password, userEntity.Salt))
      throw CustomException.RepeatPasswordException();

    userEntity.Salt = authData.Salt;
    userEntity.Password = authData.Password;

    await Update(userEntity);
    return userEntity;
  }

  public async Task<User> UpdateUser(UserDto userDto)
  {
    var userEntity = await Get(userDto.Id);

    userEntity.Email = userDto.Email;
    userEntity.Role = userDto.Role;
    userEntity.Name = userDto.Name;

    if (!string.IsNullOrEmpty(userDto.Avatar))
    {
      if (userEntity.Avatar is null)
      {
        var image = BuildImageEntity(userDto.Avatar);

        userEntity.Avatar = image;
        await _imageService.CreateImage(image);

        var imageId = (await _imageService.GetEntityByUrl(image.URL)).Id;

        userEntity.AvatarId = imageId;
        userEntity.Avatar.Id = imageId;
      }
      else
      {
        userEntity.Avatar.URL = userDto.Avatar;
        userEntity.Avatar.UpdatedAt = DateTime.Now;

        await _imageService.UpdateImage(userEntity.Avatar);
      }
    }
    else
    {
      if (userEntity.Avatar is not null)
      {
        await _imageService.Remove(userEntity.Avatar);
      }
    }

    await Update(userEntity);
    return userEntity;
  }

  public async Task<User?> Get(int userId)
  {
    var user = await _repository.GetByIdAsync(userId);

    if (user is null)
      throw new NotFoundException(nameof(user), userId);

    return user;
  }

  public async Task<User?> Get(string email)
  {
    var user = await _repository.GetByEmailAsync(email);;

    if (user is null)
      throw new NotFoundException(nameof(user), email);

    return user;
  }

  public async Task<IEnumerable<User>> GetAll() =>
    await _repository.GetAllAsync();

  private static (string Salt, string Password) EncodeUserPassword(string password)
  {
    var salt = SecurityHelper.GetRandomBytes();

    var saltPassword = Convert.ToBase64String(salt);
    var hashedPassword = SecurityHelper.HashPassword(password, salt);

    return (saltPassword, hashedPassword);
  }

  private async Task ValidateUserIsExistByEmail(string email)
  {
    var user = await _repository.GetByEmailAsync(email);

    if (user is not null)
      throw new RepeatException(nameof(user), email);
  }

  private static Image BuildImageEntity(string url) =>
    new()
    {
      URL = url
    };
}
