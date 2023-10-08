using System.Net;
using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Enums;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class BookingService : BaseService<IBookingRepository, Booking>, IBookingService
{
  private readonly IRouteService _routeService;
  private readonly IUserService _userService;

  public BookingService(
    IUserService userService,
    IRouteService routeService,
    IBookingRepository repository,
    IMapper mapper) : base(repository, mapper)
  {
    _userService = userService;
    _routeService = routeService;
  }

  public async Task<int> CreateBooking(Booking model)
  {
    await ValidateBookingRouteId(model.RouteId);
    await ValidateBookingUserId(model.UserId);

    model.Uid = Guid.NewGuid();
    await Create(model);

    await ValidateBookingUid(model.Uid);

    return (await GetBooking(model.Uid)).Id;
  }

  public async Task<Booking> UpdateBooking(Booking model)
  {
    await ValidateBookingRouteId(model.RouteId);
    await ValidateBookingUserId(model.UserId);
    await ValidateBookingUid(model.Uid);

    await Update(model);
    return await GetBooking(model.Id);
  }

  public async Task Delete(int bookingId)
  {
    var bookingEntity = await GetBooking(bookingId);

    if (bookingEntity is null)
      throw new NotFoundException(nameof(bookingEntity), bookingId);

    await Delete(bookingEntity);
  }

  public Task<decimal> CalculatePrice(DateTime startDate, DateTime endDate, int seats, decimal price)
  {
    if (endDate <= startDate || seats <= 0 || price <= 0)
      throw new CustomException("Invalid parameters provided!", HttpStatusCode.BadRequest);

    var countDays = (endDate - startDate).Days;
    return Task.FromResult(seats * price * countDays);
  }

  public async Task<IEnumerable<Booking>> GetBookingsByUser(int userId) =>
    await _repository.GetBookingsByUserId(userId);

  public async Task<IEnumerable<Booking>> GetAllBookings() =>
    await _repository.GetAllAsync();

  public async Task<IEnumerable<RouteEntity>> GetPopularBookings(WorldParts? worldParts)
  {
    var routeIds = await _repository.GetFrequentBookings();
    var routes = new List<RouteEntity>();

    foreach (var routeId in routeIds)
    {
      var route = await _routeService.Get(routeId);

      if (route is not null && (worldParts is null || route.WorldPart == worldParts))
      {
        routes.Add(route);
      }
    }

    return routes;
  }

  public async Task<Booking?> GetBooking(int bookingId) =>
    await _repository.FirstOrDefaultAsync(x => x.Id == bookingId);

  private async Task<Booking?> GetBooking(Guid uid) =>
    await _repository.FirstOrDefaultAsync(x => x.Uid == uid);

  private async Task ValidateBookingRouteId(int bookingRouteId)
  {
    var routeEntity = await _routeService.Get(bookingRouteId);

    if (routeEntity is null)
      throw new NotFoundException(nameof(routeEntity), bookingRouteId);
  }

  private async Task ValidateBookingUserId(int bookingUserId)
  {
    var userEntity = await _userService.Get(bookingUserId);

    if (userEntity is null)
      throw new NotFoundException(nameof(userEntity), bookingUserId);
  }

  private async Task ValidateBookingUid(Guid modelUid)
  {
    var entity = await GetBooking(modelUid);

    if (entity is null)
      throw new CustomException($"Error creation model: {modelUid}!", HttpStatusCode.BadRequest);
  }
}
