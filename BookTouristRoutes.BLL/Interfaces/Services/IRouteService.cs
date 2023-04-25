using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Services;

public interface IRouteService
{
  Task<RouteDto> CreateRoute(Route route);
  Task<Route> Update(RouteDto routeDto);
  Task Delete(int routeId);
  Task<IEnumerable<Route>> Search(string destination, DateTime? startDate, decimal? price);
  Task<int> GetAvailableSeats(int routeId);
  Task<int> GetBookedSeats(int routeId);
  Task<int> GetSeatsCapacity(int routeId);
  Task<IEnumerable<Route>> GetAll();
  Task<Route?> Get(int routeId);
  Task<Route?> Get(string name);
}
