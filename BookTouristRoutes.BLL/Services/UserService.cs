using System.Net;
using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Repositories;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class UserService : BaseService<UserRepository, User>, IUserService
{
  private readonly ImageService _imageService;

  public UserService(
    UserRepository userRepository,
    ImageRepository imageRepository,
    IMapper mapper) : base(userRepository, mapper)
  {
    _imageService = new ImageService(imageRepository, mapper);
  }

  public async Task<int> CreateUser(RegisterUserDto registerUser)
  {
    await ValidateUserIsExistByEmail(registerUser.Email);

    var user = _mapper.Map<User>(registerUser);

    await Create(user);
    return (await _repository.FirstAsync(x => x.Email == user.Email)).Id;
  }

  public async Task Delete(int userId)
  {
    var user = await Get(userId);
    await Delete(user);
  }

  public async Task<User> ChangePassword(int userId, string newPassword)
  {
    var userEntity = await Get(userId);

    userEntity.Password = newPassword;

    await Update(userEntity);
    return userEntity;
  }

  public async Task<User> UpdateUser(UserDto userDto)
  {
    var userEntity = await Get(userDto.Id);

    userEntity.Email = userDto.Email;

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
      throw CustomException.EntityNotFound(nameof(user), userId);

    return user;
  }

  public async Task<User?> Get(string email)
  {
    var user = await _repository.GetByEmailAsync(email);;

    if (user is null)
      throw CustomException.EntityNotFound(nameof(user), email);

    return user;
  }

  public async Task<IEnumerable<User>> GetAll() =>
    await _repository.GetAllAsync();

  private async Task ValidateUserIsExistByEmail(string email)
  {
    var user = await _repository.GetByEmailAsync(email);

    if (user is not null)
      throw new CustomException("User with the same email is exist in system!", HttpStatusCode.BadRequest);
  }

  private static Image BuildImageEntity(string url) =>
    new()
    {
      URL = url
    };
}
