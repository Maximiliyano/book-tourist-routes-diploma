using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Repositories;

public interface IRouteRepository : IRepository<RouteEntity>
{
  Task<IEnumerable<RouteEntity>> GetAllAsync();
  Task<IEnumerable<RouteEntity>> Search(string destination, DateTime? startDate, decimal? price);
}
