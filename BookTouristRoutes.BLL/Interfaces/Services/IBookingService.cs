using BookTouristRoutes.Common.Enums;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Services;

public interface IBookingService
{
  Task<int> CreateBooking(Booking model);
  Task<Booking> UpdateBooking(Booking model);
  Task<IEnumerable<Booking>> GetBookingsByUser(int userId);
  Task<IEnumerable<Booking>> GetAllBookings();
  Task<IEnumerable<RouteEntity>> GetPopularBookings(WorldParts? worldParts);
  Task<Booking?> GetBooking(int bookingId);
  Task Delete(int bookingId);
  Task<decimal> CalculatePrice(DateTime startDate, DateTime endDate, int seats, decimal price);
}
