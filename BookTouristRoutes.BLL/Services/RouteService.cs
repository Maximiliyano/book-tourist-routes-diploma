using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class RouteService : BaseService<IRouteRepository, Route>, IRouteService
{
  public RouteService(IRouteRepository routeRepository, IMapper mapper) : base(routeRepository, mapper)
  {
  }

  public async Task<RouteDto> CreateRoute(Route route)
  {
    await ValidateRouteIsExistByName(route.Name);

    await Create(route);

    var entity = await Get(route.Name);
    return _mapper.Map<RouteDto>(entity);
  }

  public async Task<Route> Update(RouteDto routeDto)
  {
    var actualRoute = await Get(routeDto.Id);

    actualRoute.Name = routeDto.Name;
    actualRoute.Description = routeDto.Description;
    actualRoute.Destination = routeDto.Destination;
    actualRoute.Price = routeDto.Price;
    actualRoute.Seats = routeDto.Seats;
    actualRoute.BookedSeats = routeDto.BookedSeats;
    actualRoute.StartDate = routeDto.StartDate;
    actualRoute.EndDate = routeDto.EndDate;

    await Update(actualRoute);
    return actualRoute;
  }

  public async Task<IEnumerable<Route>> Search(string destination, DateTime? startDate, decimal? price) =>
    await _repository.Search(destination, startDate, price);

  public async Task<int> GetSeatsCapacity(int routeId)
  {
    var route = await Get(routeId);

    if (route is null)
      throw CustomException.EntityNotFound(nameof(route), routeId);

    return route.Seats;
  }

  public async Task<int> GetAvailableSeats(int routeId)
  {
    var route = await Get(routeId);

    if (route is null)
      throw CustomException.EntityNotFound(nameof(route), routeId);

    return route.Seats - route.BookedSeats;
  }

  public async Task<int> GetBookedSeats(int routeId)
  {
    var route = await Get(routeId);

    if (route is null)
      throw CustomException.EntityNotFound(nameof(route), routeId);

    return route.BookedSeats;
  }

  public async Task<IEnumerable<Route>> GetAll() =>
    await _repository.GetAllAsync();

  public async Task<Route?> Get(string name) =>
    await _repository.FirstOrDefaultAsync(x => x.Name == name);

  public async Task<Route?> Get(int routeId) =>
    await _repository.FirstOrDefaultAsync(x => x.Id == routeId);

  private async Task ValidateRouteIsExistByName(string name)
  {
    var route = await Get(name);

    if (route is not null)
      throw CustomException.RepeatException(nameof(route), name);
  }
}
