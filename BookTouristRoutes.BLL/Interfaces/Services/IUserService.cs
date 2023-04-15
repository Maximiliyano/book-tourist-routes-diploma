using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Services;

public interface IUserService
{
  Task<UserDto> CreateUser(RegisterUserDto registerUser);
  Task<User> ChangePassword(int userId, string newPassword);
  Task<User> UpdateUser(UserDto userDto);
  Task Delete(int userId);
  Task<User?> Get(int userId);
  Task<User?> Get(string email);
  Task<IEnumerable<User>> GetAll();
}
