using BookTouristRoutes.Common.Enums;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Services;

public interface IRouteService
{
  Task<RouteEntity> CreateRoute(RouteEntity routeEntity);
  Task<RouteEntity> UpdateRoute(RouteEntity routeEntityDto);
  Task DeleteRoute(int routeId);
  Task<IEnumerable<RouteEntity>> Search(string destination, DateTime? startDate, decimal? price, WorldParts? worldParts);
  Task<int> GetAvailableSeats(int routeId);
  Task<int> GetBookedSeats(int routeId);
  Task<int> GetSeatsCapacity(int routeId);
  Task<IEnumerable<RouteEntity>> GetAll();
  Task<RouteEntity?> Get(int routeId);
  Task<RouteEntity?> Get(string name);
}
