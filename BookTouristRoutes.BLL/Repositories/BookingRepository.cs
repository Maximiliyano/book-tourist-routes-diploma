using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.BLL.Repositories;

public class BookingRepository : Repository<Booking>, IBookingRepository
{
  private readonly BookTouristRoutesContext _context;

  public BookingRepository(BookTouristRoutesContext context) : base(context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Booking>> GetAllAsync() =>
    await _context.Bookings
      .AsNoTracking()
      .ToListAsync();

  public async Task<IEnumerable<Booking>> GetBookingsByUserId(int userId) =>
    await _context.Bookings
      .Where(x => x.UserId == userId)
      .AsNoTracking()
      .ToListAsync();
}
