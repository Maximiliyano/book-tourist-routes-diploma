using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
  Task<IEnumerable<User>> GetAllAsync();
  Task<User?> GetByIdAsync(int userId);
  Task<User?> GetByEmailAsync(string userEmail);
}
