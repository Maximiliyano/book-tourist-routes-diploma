using System.Net;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Extensions;
using BookTouristRoutes.Common.Models.User;

namespace BookTouristRoutes.BLL.Services;

public class UserService : BaseService<Repository<UserDto>, UserDto>, IUserService
{
  public UserService(UserRepository userRepository) : base(userRepository)
  {
  }

  public async Task<int> CreateAsync(RegisterUser registerUser)
  {
    await ValidateUserIsExistByName(registerUser.Name);

    var userDto = _mapper.Map<UserDto>(registerUser);

    await Create(userDto);
    return (await _repository.FirstAsync(x => x.Name == userDto.Name)).Id;
  }

  public async Task Delete(int userId)
  {
    var userDto = await ValidateUserIsNotExistById(userId);
    await Delete(userDto);
  }

  public async Task<User> Update(UpdateUser updateUser)
  {
    var user = await ValidateUserIsNotExistById(updateUser.Id);
    await ValidateUserIsExistByName(updateUser.Name);

    var userDto = _mapper.Map<UserDto>(updateUser);
    userDto.CreatedAt = user.CreatedAt;

    await Update(userDto);
    return _mapper.Map<User>(userDto);
  }

  public async Task<User?> Get(int userId)
  {
    var userDto = await _repository.GetByIdAsync(userId);
    return userDto is not null ? _mapper.Map<User>(userDto) : null;
  }

  public async Task<User?> Get(string name)
  {
    var userDto = await _repository.FirstOrDefaultAsync(x => x.Name == name);
    return userDto is not null ? _mapper.Map<User>(userDto) : null;
  }

  public async Task<IEnumerable<User>> GetAll() =>
    await _repository.GetAllAsync();

  private async Task ValidateUserIsExistByName(string name)
  {
    var user = await _repository.FirstOrDefaultAsync(x => x.Name == name);

    if (user is not null)
      throw new CustomException("User with the same name is exist in system!", HttpStatusCode.BadRequest);
  }

  private async Task<UserDto> ValidateUserIsNotExistById(int userId)
  {
    var userDto = await _repository.FirstOrDefaultAsync(x => x.Id == userId);

    if (userDto is null)
      throw new CustomException("User is not exist in system!", HttpStatusCode.NotFound);

    return userDto;
  }
}
