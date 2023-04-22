using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class RouteService : BaseService<IRouteRepository, Route>, IRouteService
{
  public RouteService(IRouteRepository routeRepository, IMapper mapper) : base(routeRepository, mapper)
  {
  }
}
