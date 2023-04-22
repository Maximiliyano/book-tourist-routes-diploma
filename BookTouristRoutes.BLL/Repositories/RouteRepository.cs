using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.DAL.Context;

namespace BookTouristRoutes.BLL.Repositories;

public class RouteRepository : Repository<Route>, IRouteRepository
{
  public RouteRepository(BookTouristRoutesContext context) : base(context)
  {
  }
}
