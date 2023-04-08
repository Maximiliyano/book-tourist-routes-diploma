using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.DAL.Context;

namespace BookTouristRoutes.BLL.Repositories;

public class UserRepository : Repository<UserDto> // TODO OOP please
{
  private readonly BookTouristRoutesContext _context;

  public UserRepository(BookTouristRoutesContext context) : base(context)
  {
    _context = context;
  }
}
