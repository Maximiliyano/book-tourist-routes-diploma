using BookTouristRoutes.Common.Builders;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Enums;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints;

namespace BookTouristRoutes.Tests.Helpers;

public class BookingHelper
{
  private readonly BookingApi _bookingApi;

  public BookingHelper()
  {
    _bookingApi = new BookingApi();
  }

  public async Task<int> Create(
    int routeId, int userId,
    DateTime? startDate = null, DateTime? endDate = null,
    BookingStatus? status = null,
    decimal? price = null)
  {
    var bookingEntity = GlobalBuilder.BuildBooking(routeId, userId, startDate, endDate, status, price);
    return (await _bookingApi.Create(bookingEntity)).Data;
  }

  public async Task<decimal> CalculatePrice(BookingFilterDto bookingFilterDto) =>
    (await _bookingApi.CalculatePrice(bookingFilterDto)).Data;

  public async Task<Booking?> Get(int bookingId) =>
    (await _bookingApi.Get(bookingId)).Data;

  public async Task<IEnumerable<Booking>> GetAll() =>
    (await _bookingApi.GetAll()).Data;

  public async Task<IEnumerable<Booking>> GetByUser(int userId) =>
    (await _bookingApi.GetByUser(userId)).Data;

  public async Task<Booking> Update(Booking booking) =>
    (await _bookingApi.Update(booking)).Data;

  public async Task Delete(int bookingId) =>
    await _bookingApi.Delete(bookingId);
}
