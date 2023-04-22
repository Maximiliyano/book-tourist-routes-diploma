using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.Common.BaseEntities;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Route("api/route")]
public class RouteController : BaseController
{
  private readonly IRouteService _routeService;

  public RouteController(IRouteService routeService)
  {
    _routeService = routeService;
  }
}
