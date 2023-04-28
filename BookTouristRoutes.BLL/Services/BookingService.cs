using System.Net;
using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class BookingService : BaseService<IBookingRepository, Booking>, IBookingService
{
  public BookingService(IBookingRepository repository, IMapper mapper) : base(repository, mapper)
  {
  }

  public async Task<int> CreateBooking(Booking model)
  {
    model.Uid = new Guid();
    await Create(model);

    await ValidateCreationModel(model);

    return (await GetBooking(model.Uid)).Id;
  }

  public async Task<Booking> UpdateBooking(Booking model)
  {
    await Update(model);

    await ValidateCreationModel(model);

    return await GetBooking(model.Id);
  }

  public async Task Delete(int bookingId)
  {
    var bookingEntity = await GetBooking(bookingId);

    if (bookingEntity is null)
      throw CustomException.EntityNotFound(nameof(bookingEntity), bookingId);

    await Delete(bookingEntity);
  }

  public async Task<decimal> CalculatePrice(DateTime startDate, DateTime endDate, int seats, decimal price)
  {
    if (startDate <= endDate || seats <= 0 || price <= 0)
      throw new CustomException("Invalid parameters provided!", HttpStatusCode.BadRequest);

    var countDays = (endDate - startDate).Days;
    return seats * price * countDays;
  }

  public async Task<IEnumerable<Booking>> GetBookingsByUser(int userId) =>
    await _repository.GetBookingsByUserId(userId);

  public async Task<IEnumerable<Booking>> GetAllBookings() =>
    await _repository.GetAllAsync();

  public async Task<Booking?> GetBooking(int bookingId) =>
    await _repository.FirstOrDefaultAsync(x => x.Id == bookingId);

  private async Task<Booking?> GetBooking(Guid uid) =>
    await _repository.FirstOrDefaultAsync(x => x.Uid == uid);

  private async Task ValidateCreationModel(Booking model)
  {
    var entity = await GetBooking(model.Uid);

    if (entity is null)
      throw new CustomException($"Error creation model: {model}!", HttpStatusCode.BadRequest);
  }
}
