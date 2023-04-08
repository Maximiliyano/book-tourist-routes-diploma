using System.Linq.Expressions;
using System.Net;
using BookTouristRoutes.BLL.Repositories;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Extensions;
using BookTouristRoutes.Common.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.BLL.Services;

public class UserService : BaseService
{
  private readonly UserRepository _userRepository;

  public UserService(UserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<int> Create(RegisterUser registerUser)
  {
    await ValidateUserIsExistByName(registerUser.Name);

    var userDto = _mapper.Map<UserDto>(registerUser);

    await _userRepository.AddAsync(userDto);
    return (await _userRepository.FirstAsync(x => x.Name == userDto.Name)).Id;
  }

  public async Task Delete(int userId)
  {
    var userDto = await ValidateUserIsNotExistById(userId);
    await _userRepository.RemoveAsync(userDto);
  }

  public async Task<User> Update(User updatedUser)
  {
    //await ValidateUserIsNotExistById(updatedUser.Id); TODO this method completely
    //await ValidateUserIsExistByName(updatedUser.Name);

    var updatedUserDto = _mapper.Map<UserDto>(updatedUser);

    await _userRepository.UpdateAsync(updatedUserDto);
    return updatedUser;
  }

  public async Task<User?> Get(int userId)
  {
    var userDto = await _userRepository.GetByIdAsync(userId);
    return userDto is not null ? _mapper.Map<User>(userDto) : null;
  }

  public async Task<User?> Get(string name)
  {
    var userDto = await _userRepository.FirstOrDefaultAsync(x => x.Name == name);
    return userDto is not null ? _mapper.Map<User>(userDto) : null;
  }

  public async Task<IEnumerable<User>> GetAll() =>
    await _userRepository.GetAllAsync();

  private async Task ValidateUserIsExistByName(string name)
  {
    var user = await _userRepository.FirstOrDefaultAsync(x => x.Name == name);

    if (user is not null)
      throw new CustomException("User is exist in system!", HttpStatusCode.BadRequest);
  }

  private async Task<UserDto> ValidateUserIsNotExistById(int userId)
  {
    var userDto = await _userRepository.FirstOrDefaultAsync(x => x.Id == userId);

    if (userDto is null)
      throw new CustomException("User is not exist in system!", HttpStatusCode.NotFound);

    return userDto;
  }
}
