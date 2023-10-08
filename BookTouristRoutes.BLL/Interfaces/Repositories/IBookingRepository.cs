using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Repositories;

public interface IBookingRepository : IRepository<Booking>
{
  Task<IEnumerable<Booking>> GetAllAsync();
  Task<IEnumerable<Booking>> GetBookingsByUserId(int userId);
  Task<IEnumerable<int>> GetFrequentBookings();
}
