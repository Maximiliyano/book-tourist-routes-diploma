using System.Linq.Expressions;
using System.Net;
using BookTouristRoutes.BLL.Repositories;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Extensions;
using BookTouristRoutes.Common.Models.User;
using BookTouristRoutes.DAL.Context;

namespace BookTouristRoutes.BLL.Services;

public class UserService : BaseService // TODO implement this method
{
  private readonly UserRepository _userRepository;
  private readonly BookTouristRoutesContext _context;

  public UserService(UserRepository userRepository, BookTouristRoutesContext context)
  {
    _userRepository = userRepository;
    _context = context;
  }

  public async Task<int> Create(RegisterUser registerUser)
  {
    await ValidateIsUserExist(x => x.Name == registerUser.Name);

    var userDto = _mapper.Map<UserDto>(registerUser);

    await _userRepository.AddAsync(userDto);
    return (await _userRepository.FindFirstAsync(x => x.Name == userDto.Name)).Id;
  }

  public async Task<User?> GetById(int userId)
  {
    var userDto = await _userRepository.GetByIdAsync(userId);
    return userDto is not null ? _mapper.Map<User>(userDto) : null;
  }

  public async Task<User?> GetByName(string name)
  {
    var userDto = await _userRepository.FindFirstOrDefaultAsync(x => x.Name == name);
    return userDto is not null ? _mapper.Map<User>(userDto) : null;
  }

  public async Task Delete(int userId)
  {
    var userDto = await _userRepository.FindFirstOrDefaultAsync(x => x.Id == userId);

    if (userDto is null)
      throw new CustomException("User is not exist in system!", HttpStatusCode.NotFound);

    await _userRepository.RemoveAsync(userDto);
  }

  private async Task ValidateIsUserExist(Expression<Func<UserDto, bool>> expression)
  {
    var user = await _userRepository.FindFirstOrDefaultAsync(expression);

    if (user is not null)
      throw new CustomException("User with the same name is exist!", HttpStatusCode.BadRequest);
  }
}
