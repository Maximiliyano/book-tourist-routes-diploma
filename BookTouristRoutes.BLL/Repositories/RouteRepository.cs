using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.Common.Enums;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.BLL.Repositories;

public class RouteRepository : Repository<RouteEntity>, IRouteRepository
{
  private readonly BookTouristRoutesContext _context;

  public RouteRepository(BookTouristRoutesContext context) : base(context)
  {
    _context = context;
  }

  public async Task<IEnumerable<RouteEntity>> GetAllAsync() =>
    await _context.Routes.AsNoTracking().ToListAsync();

  public async Task<IEnumerable<RouteEntity>> Search(string destination, DateTime? startDate, decimal? price, WorldParts? worldParts)
  {
    var query = _context.Routes.AsQueryable().Where(r => r.Destination == destination);

    if (startDate.HasValue)
    {
      query = query.Where(r => r.StartDate == startDate.Value);
    }

    if (price.HasValue)
    {
      query = query.Where(r => r.Price == price.Value);
    }

    if (worldParts.HasValue)
    {
      query = query.Where(r => r.WorldPart == worldParts);
    }

    return await query.ToListAsync();
  }
}
