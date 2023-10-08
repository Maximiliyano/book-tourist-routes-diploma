using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Enums;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class RouteService : BaseService<IRouteRepository, RouteEntity>, IRouteService
{
  public RouteService(
    IRouteRepository routeRepository,
    IMapper mapper) : base(routeRepository, mapper)
  {
  }

  public async Task<RouteEntity> CreateRoute(RouteEntity routeEntity)
  {
    await ValidateRouteIsExistByName(routeEntity.Name);

    await Create(routeEntity);

    var entity = await Get(routeEntity.Name);
    return entity;
  }

  public async Task<RouteEntity> UpdateRoute(RouteEntity routeEntityDto)
  {
    var entity = await Get(routeEntityDto.Id);

    if (entity is null)
      throw new NotFoundException(nameof(entity), routeEntityDto.Id);

    entity.Name = routeEntityDto.Name;
    entity.Description = routeEntityDto.Description;
    entity.Destination = routeEntityDto.Destination;
    entity.Price = routeEntityDto.Price;
    entity.Seats = routeEntityDto.Seats;
    entity.BookedSeats = routeEntityDto.BookedSeats;
    entity.StartDate = routeEntityDto.StartDate;
    entity.EndDate = routeEntityDto.EndDate;
    entity.WorldPart = routeEntityDto.WorldPart;

    await Update(entity);
    return entity;
  }

  public async Task<IEnumerable<RouteEntity>> Search(string destination, DateTime? startDate, decimal? price, WorldParts? worldParts) =>
    await _repository.Search(destination, startDate, price, worldParts);

  public async Task<int> GetSeatsCapacity(int routeId)
  {
    var route = await Get(routeId);

    if (route is null)
      throw new NotFoundException(nameof(route), routeId);

    return route.Seats;
  }

  public async Task<int> GetAvailableSeats(int routeId)
  {
    var route = await Get(routeId);

    if (route is null)
      throw new NotFoundException(nameof(route), routeId);

    return route.Seats - route.BookedSeats;
  }

  public async Task<int> GetBookedSeats(int routeId)
  {
    var route = await Get(routeId);

    if (route is null)
      throw new NotFoundException(nameof(route), routeId);

    return route.BookedSeats;
  }

  public async Task DeleteRoute(int routeId)
  {
    var route = await Get(routeId);

    if (route is null)
      throw new NotFoundException(nameof(route), routeId);

    await Delete(route);
  }

  public async Task<IEnumerable<RouteEntity>> GetAll() =>
    await _repository.GetAllAsync();

  public async Task<RouteEntity?> Get(string name) =>
    await _repository.FirstOrDefaultAsync(x => x.Name == name);

  public async Task<RouteEntity?> Get(int routeId) =>
    await _repository.FirstOrDefaultAsync(x => x.Id == routeId);

  private async Task ValidateRouteIsExistByName(string name)
  {
    var route = await Get(name);

    if (route is not null)
      throw new RepeatException(nameof(route), name);
  }
}
