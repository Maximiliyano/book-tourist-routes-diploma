using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Repositories;

public interface IRouteRepository : IRepository<Route>
{
  Task<IEnumerable<Route>> GetAllAsync();
  Task<IEnumerable<Route>> Search(string destination, DateTime? startDate, decimal? price);
}
